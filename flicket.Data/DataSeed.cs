using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flicket.Models.Entities;

namespace flicket.Data
{
    public static class DataSeed
    {
        public static void Seed(DataContext context)
        {
            context.Database.EnsureCreated();
            if (context.Flights.Any())
            {
                return;
            }

            var flights = new List<Flight>
            {
                new Flight {
                    Airline = new Airline { Name = "Lufthansa"},
                    From = new Airport { Location = "Landvetter, Gothenburg, Sweden", Name = "GOT"},
                    To = new Airport { Location = "Chania, Greece", Name = "IDK"},
                    Departure = DateTime.UtcNow.AddDays(15),
                    Arrival = DateTime.UtcNow.AddDays(15).AddHours(3),
                    BusinessPrice = 150,
                    EconomyPrice = 100
                },
                new Flight {
                    Airline = new Airline { Name = "SAS"},
                    From = new Airport { Location = "Los Angeles International Airport, Los Angeles, California, USA", Name = "LAX"},
                    To = new Airport { Location = "Athens, Greece", Name = "ATH"},
                    Departure = DateTime.UtcNow.AddDays(10),
                    Arrival = DateTime.UtcNow.AddDays(10).AddHours(5),
                    BusinessPrice = 250,
                    EconomyPrice = 500
                }
            };

            context.Flights.AddRange(flights);
            context.SaveChanges();
        }
    }
}
