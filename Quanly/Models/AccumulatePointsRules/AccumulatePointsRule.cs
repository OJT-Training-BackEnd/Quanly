using Quanly.Models.AccumulatePoints;

namespace Quanly.Models.AccumulatePointsRules
{
    public class AccumulatePointsRule : ModelBase
    {
        public int Id { get; set; }
        public string? Code { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public DateTime? ApplyFrom { get; set; }
        public DateTime? ApplyTo { get; set; }
        public string? Guide { get; set; } = string.Empty;
        public string? Formula { get; set; }
        public List<AccumulatePoint>? AccumulatePoint { get; set; }
    }
}