using Quanly.Models.ContactPersons;
using Quanly.Models.MemberCards;
using System.ComponentModel.DataAnnotations;

namespace Quanly.Models.Customers
{
    public class Customer : ModelBase
    {
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        [StringLength(11, MinimumLength = 10)]
        public int Phone { get; set; }
        [StringLength(11, MinimumLength = 10)]
        public int TelePhone { get; set; }
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public bool IsMarried { get; set; } = false;
        public DateTime BirthDate { get; set; }
        public string IdentityCard { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        [StringLength(11, MinimumLength = 10)]
        public int CompanyPhone { get; set; }
        public string Contact { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public int Age { get; set; }
        public DateTime DateOfRecord { get; set; } = DateTime.Now;
        public int Points { get; set; }
        public bool IsActive { get; set; } = true;
        public List<MemberCard>? MemberCards { get; set; }
        public ContactPerson? ContactPersons { get; set; }
    }
}
