using Quanly.Models.AccumulatePoints;
using Quanly.Models.Customers;
using System.ComponentModel.DataAnnotations;

namespace Quanly.Models.MemberCards
{
    public class MemberCard : ModelBase
    {
        public int Id { get; set; }
        [Required]
        public int CardNumber { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; }
        public DateTime EffectDate { get; set; }
        public DateTime ValidDate { get; set; }
        public Customer Customer { get; set; }
        public string RegisterAt { get; set; } = string.Empty;
        public List<AccumulatePoint>? AccumulatePoints { get; set; }
    }
}
