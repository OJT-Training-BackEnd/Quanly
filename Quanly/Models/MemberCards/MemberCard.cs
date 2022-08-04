using Quanly.Models.AccumulatePoints;
using Quanly.Models.Customers;
using System.ComponentModel.DataAnnotations;

namespace Quanly.Models.MemberCards
{
    public class MemberCard : ModelBase
    {
        public int? Id { get; set; }
        [StringLength(10, ErrorMessage = "Do not enter more than 10 characters")]
        public string? CardNumber { get; set; }
        public string? Type { get; set; } = "Thẻ Thành Viên";
        [StringLength(20, ErrorMessage = "Do not enter more than 20 characters")]
        public string? Reason { get; set; } = string.Empty;
        public DateTime? IssueDate { get; set; }
        public DateTime? EffectDate { get; set; }
        public DateTime? ValidDate { get; set; }
        public Customer? Customer { get; set; }
        public bool IsActive { get; set; } = true;
        public string? RegisterAt { get; set; } = string.Empty;
        public List<AccumulatePoint>? AccumulatePoints { get; set; }
    }
}