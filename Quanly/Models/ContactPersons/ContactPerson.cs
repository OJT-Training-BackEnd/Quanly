using System.ComponentModel.DataAnnotations;

namespace Quanly.Models.ContactPersons
{
    public class ContactPerson
    {
        public int Id { get; set; }
        public string? FullName { get; set; } = string.Empty;
        public string? Position { get; set; } = string.Empty;
        public string? Department { get; set; } = string.Empty;
        [StringLength(11, MinimumLength = 10)]
        public string? Phone { get; set; }
        public string? Email { get; set; } = string.Empty;
        public int? CustomerId { get; set; }
    }
}
