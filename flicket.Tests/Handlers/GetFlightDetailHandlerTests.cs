using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using AutoMapper;
using flicket.Data;
using flicket.Logic.FlightHandlers;
using flicket.Logic.Profiles;
using flicket.Models;
using flicket.Models.Entities;
using FluentAssertions;
using TestSupport.EfHelpers;
using Xunit;

namespace flicket.Tests.Handlers
{
    public class GetFlightDetailHandlerTests : IDisposable
    {
        private readonly DataContext _context = new(SqliteInMemory.CreateOptions<DataContext>());
        private GetFlightDetailHandler _sut;
        private readonly IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddMaps(typeof(FlightProfiles).Assembly)));

        public GetFlightDetailHandlerTests()
        {
            _context.Database.EnsureCreated();
        }

        [Theory, AutoData]
        public async Task GetFlightDetailHandler_Returns_FlightDetailVM(Flight flight)
        {
            _context.Add(flight);
            _context.SaveChanges();

            _sut = new(_context, _mapper);
            var result = await _sut.Handle(new GetFlightDetailQuery(flight.Id), default);
            result.Should().NotBeNull();
            result.Id.Should().Be(flight.Id);
            result.Airline.Should().NotBeNull();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
