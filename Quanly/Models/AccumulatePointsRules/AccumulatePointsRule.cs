﻿using Quanly.Models.AccumulatePoints;

namespace Quanly.Models.AccumulatePointsRules
{
    public class AccumulatePointsRule : ModelBase
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public DateTime? ApplyFrom { get; set; }
        public DateTime? ApplyTo { get; set; }
        public string? Guide { get; set; } = string.Empty;
        public int? Formula { get; set; }
        public List<AccumulatePoint>? AccumulatePoint { get; set; }
    }
}
