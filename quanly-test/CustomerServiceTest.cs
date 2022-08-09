using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Quanly.Data;
using Quanly.Models.Customers;
using Quanly.Services.CustomerService;
using Quanly.ValidationHandling.CustomerValidation;

namespace quanly_test
{
    public class Tests
    {
        private static DbContextOptions<DataContext> dbContextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "quanlyDbTest")
                .Options;

        DataContext context;
        CustomerService customerService;
        
        ValidGetAllCus _validation;
        ValidDeleteCus _validDeleteCus;
        IHttpContextAccessor _httpContextAccessor;
        CustomerValidation _customerValidation;
        [OneTimeSetUp]
        public void Setup()
        {
            context = new DataContext(dbContextOptions);
            context.Database.EnsureCreated();

            SeedDatabase();

            customerService = new CustomerService(context,_validation,_validDeleteCus,_httpContextAccessor,_customerValidation);
        }
        
        
        [OneTimeTearDown]
        public void cleanUp()
        {
            context.Database.EnsureDeleted();
        }


        private void SeedDatabase()
        {
            var _customers = new List<Customer>
            {
                new Customer()
                {
                    Id  = 1,
                    CustomerName = "Kiet",
                    Address = "12",
                    Age = "2",
                    Code = "KA1231",
                    Email = "kiet@gmail.com",
                    Gender = "Men",
                    CompanyName = "TMA"
                },
                new Customer()
                {
                    Id  = 2,
                    CustomerName = "Kiet 2",
                    Address = "123",
                    Age = "22",
                    Code = "KA1232",
                    Email = "kiet2@gmail.com",
                    Gender = "Men",
                    CompanyName = "TMA"
                },
                new Customer()
                {
                    Id  = 3,
                    CustomerName = "Kiet 3",
                    Address = "123",
                    Age = "22",
                    Code = "KA1233",
                    Email = "kiet3@gmail.com",
                    Gender = "Men",
                    CompanyName = "TMA"
                },
            };
            context.Customers.AddRange(_customers);

            context.SaveChanges();
        }

        
    }
}