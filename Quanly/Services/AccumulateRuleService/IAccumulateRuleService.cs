﻿using Quanly.Models.AccumulatePointsRules;

namespace Quanly.Services.AccumulateRuleService
{
    public interface IAccumulateRuleService
    {
        Task<ServiceResponse<AccumulatePointsRule>> UpdateAccumulatePointsRule(AccumulatePointsRule apr);
    }
}