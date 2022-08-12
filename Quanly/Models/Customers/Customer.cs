using Quanly.Models.ContactPersons;
using Quanly.Models.MemberCards;
using System.ComponentModel.DataAnnotations;

namespace Quanly.Models.Customers
{
    public class Customer : ModelBase
    {
        public int? Id { get; set; }
        public string? CustomerName { get; set; } = string.Empty;
        public string? Code { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? Type { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? TelePhone { get; set; }
        public string? Email { get; set; } = string.Empty;
        public string? Fax { get; set; } = string.Empty;
        public string? Gender { get; set; } = string.Empty;
        public bool? IsMarried { get; set; } = false;
        public DateTime? BirthDate { get; set; }
        public string? IdentityCard { get; set; } = string.Empty;
        public DateTime? IssueDate { get; set; }
        public string? CompanyName { get; set; } = string.Empty;
        public string? CompanyPhone { get; set; }
        public string? Contact { get; set; } = string.Empty;
        public string? Position { get; set; } = string.Empty;
        public string? Province { get; set; } = string.Empty;
        public string? District { get; set; } = string.Empty;
        public string? Language { get; set; } = string.Empty;
        public string? Age { get; set; }
        public DateTime? DateOfRecord { get; set; }
        public string? Points { get; set; } = "0";
        public bool? IsActive { get; set; } = true;
        public List<MemberCard>? MemberCards { get; set; }
        public List<ContactPerson>? ContactPersons { get; set; }
    }
}