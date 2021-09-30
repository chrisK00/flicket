using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flicket.Constants;
using flicket.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace flicket.Data
{
    public static class DataSeed
    {
        public static async Task SeedAsync(DataContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            if (userManager.Users.Any())
            {
                return;
            }

            var adminRole = new IdentityRole { Name = Role.Admin };
            var companyRole = new IdentityRole { Name = Role.Company };
            var customerRole = new IdentityRole { Name = Role.Customer };
           
            await AddRoles(roleManager, adminRole, companyRole, customerRole);

            var adminUser = new IdentityUser { UserName = "admin@gmail.com", Email = "admin@gmail.com" };
            var companyUser = new AppUser { UserName = "company@gmail.com", Email = "company@gmail.com" };
            var customerUser = new AppUser { UserName = "customer@gmail.com", Email = "customer@gmail.com" };
          
            await AddUsers(userManager, adminRole, companyRole, customerRole, adminUser, companyUser, customerUser);

            var company = new Company { Name = "SAS Ltd" };
            context.Add(company);
            context.SaveChanges();

            var flights = new List<Flight>
            {
                new Flight {
                    Airline = new Airline { Name = "Lufthansa"},
                    From = new Airport { Location = "Landvetter, Gothenburg, Sweden", Name = "GOT"},
                    To = new Airport { Location = "Chania, Greece", Name = "IDK"},
                    Departure = DateTime.UtcNow.AddDays(15),
                    Arrival = DateTime.UtcNow.AddDays(15).AddHours(3),
                    BusinessPrice = 150,
                    EconomyPrice = 100,
                    CompanyId = company.Id
                },
                new Flight {
                    Airline = new Airline { Name = "SAS"},
                    From = new Airport { Location = "Los Angeles International Airport, Los Angeles, California, USA", Name = "LAX"},
                    To = new Airport { Location = "Athens, Greece", Name = "ATH"},
                    Departure = DateTime.UtcNow.AddDays(10),
                    Arrival = DateTime.UtcNow.AddDays(10).AddHours(5),
                    BusinessPrice = 250,
                    EconomyPrice = 500,
                    CompanyId = company.Id
                }
            };
            context.Flights.AddRange(flights);
            context.SaveChanges();

            var ticket = new Ticket { FlightId = flights[0].Id, CompanyId = company.Id, Seat = new Seat { Position = "sdfa32" } };

            context.Tickets.Add(ticket);
            context.SaveChanges();
        }

        private static async Task AddRoles(RoleManager<IdentityRole> roleManager, IdentityRole adminRole, IdentityRole companyRole, IdentityRole customerRole)
        {
            await roleManager.CreateAsync(adminRole);
            await roleManager.CreateAsync(customerRole);
            await roleManager.CreateAsync(companyRole);
        }

        private static async Task AddUsers(UserManager<IdentityUser> userManager, IdentityRole adminRole, IdentityRole companyRole, IdentityRole customerRole, IdentityUser adminUser, AppUser companyUser, AppUser customerUser)
        {
            await userManager.CreateAsync(adminUser, "password");
            await userManager.CreateAsync(companyUser, "password");
            await userManager.CreateAsync(customerUser, "password");

            await userManager.AddToRoleAsync(adminUser, adminRole.Name);
            await userManager.AddToRoleAsync(companyUser, companyRole.Name);
            await userManager.AddToRoleAsync(customerUser, customerRole.Name);
        }
    }
}
