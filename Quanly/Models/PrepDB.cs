using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quanly.Data;

namespace Quanly.Models
{
    public class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<DataContext>());
            }
        }

        public static void SeedData(DataContext context)
        {
            System.Console.WriteLine("Appling Migrations...");

            context.Database.Migrate();

            if (!context.Customers.Any())
            {
                System.Console.WriteLine("Adding data - seeding...");
                context.Customers.AddRange(
                  new Customers.Customer()
                  {
                      Id = 1,
                      Code = "KH123456789",
                      CustomerName = "Cong Chinh",
                      Address = "District 9, Ho Chi Minh City",
                      Type = "Silver",
                      Phone = "0123456789",
                      TelePhone = "01234567891",
                      Email = "Chinhpro@gmail.com",
                      Fax = "+84 (8) 3823 3318",
                      Gender = "Male",
                      BirthDate = DateTime.Now,
                      IdentityCard = "343456771234",
                      IssueDate = DateTime.Now,
                      CompanyName = "KNS",
                      CompanyPhone = "01234567891",
                      Contact = "An Ngo",
                      Position = "Head of KNS",
                      District = "District 9",
                      Language = "Vietnamese",
                      Age = "20",
                      DateOfRecord = DateTime.Now,
                      Importer = "Ad",
                  }
                );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already have data - not seeding");
            }
        }
    }
}