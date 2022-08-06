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
            System.Console.WriteLine("hehe...");

        }
    }
}