using Quanly.Models.AccumulatePointsRules;
using Quanly.Models.MemberCards;
using System.ComponentModel.DataAnnotations;

namespace Quanly.Models.AccumulatePoints
{
    public class AccumulatePoint : ModelBase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [Required, StringLength(200)]
        public string Reason { get; set; } = string.Empty;
        public MemberCard MemberCards { get; set; }
        public string Type { get; set; } = string.Empty;
        public int Money { get; set; }
        public int Points { get; set; }
        public string Shop { get; set; } = string.Empty;
        public AccumulatePointsRule AccumulatePointsRules { get; set; }
    }
}
