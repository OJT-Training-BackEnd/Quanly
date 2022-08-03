using Microsoft.EntityFrameworkCore;
using Quanly.Models.AccumulatePoints;
using Quanly.Models.AccumulatePointsRules;
using Quanly.Models.ContactPersons;
using Quanly.Models.Customers;
using Quanly.Models.MemberCards;
using Quanly.Models.User;

namespace Quanly.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasData(
                    new Customer { 
                        Id = 1,
                        Code = "KH123456789",
                        CustomerName = "Cong Chinh",
                        Address = "District 9, Ho Chi Minh City",   
                        Type = "Silver",
                        Phone = 01234567891,
                        TelePhone = 01234567891,
                        Email = "Chinhpro@gmail.com",
                        Fax = "+84 (8) 3823 3318",
                        Gender = "Male",
                        BirthDate = DateTime.Now,
                        IdentityCard = "343456771234",
                        IssueDate = DateTime.Now,
                        CompanyName = "KNS",
                        CompanyPhone = 01234567891,
                        Contact = "An Ngo",
                        Position = "Head of KNS",
                        District = "District 9",
                        Language = "Vietnamese",
                        Age = 20,
                        DateOfRecord = DateTime.Now,
                        Importer = "Ad",
                        Updater = "Ad",
                    }
                );
        }

        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MemberCard> MemberCards { get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }
        public DbSet<AccumulatePoint> AccumulatePoints { get; set; }
        public DbSet<AccumulatePointsRule> AccumulatePointsRules { get; set; }
    }
}
