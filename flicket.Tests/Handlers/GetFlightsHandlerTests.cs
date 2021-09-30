using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using AutoMapper;
using flicket.Data;
using flicket.Logic.FlightHandlers;
using flicket.Logic.Profiles;
using flicket.Logic.TicketHandlers;
using flicket.Models;
using flicket.Models.Entities;
using flicket.Models.Params;
using FluentAssertions;
using TestSupport.EfHelpers;
using Xunit;

namespace flicket.Tests.Handlers
{
    public class GetFlightsHandlerTests : IDisposable
    {
        private readonly DataContext _context = new(SqliteInMemory.CreateOptions<DataContext>());
        private GetFlightsHandler _sut;
        private readonly IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddMaps(typeof(FlightProfile).Assembly)));

        public GetFlightsHandlerTests()
        {
            _context.Database.EnsureCreated();
        }

        [Theory, AutoData]
        public async Task GetFlightsHandler_Returns_Flights(List<Flight> flights)
        {
            _context.AddRange(flights);
            _context.SaveChanges();

            _sut = new(_context, _mapper);
            var result = await _sut.Handle(new GetFlightsQuery(new FlightParams()), default);
            result.Count().Should().BeGreaterThan(0);
        }

#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
        public void Dispose()
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
        {
            _context.Dispose();
        }
    }
}
