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

        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MemberCard> MemberCards { get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }
        public DbSet<AccumulatePoint> AccumulatePoints { get; set; }
        public DbSet<AccumulatePointsRule> AccumulatePointsRules { get; set; }
    }
}
