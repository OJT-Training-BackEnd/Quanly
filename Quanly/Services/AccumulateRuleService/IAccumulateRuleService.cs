using Quanly.Models.AccumulatePointsRules;

namespace Quanly.Services.AccumulateRuleService
{
    public interface IAccumulateRuleService
    {
        Task<ServiceResponse<AccumulatePointsRule>> UpdateAccumulatePointsRule(AccumulatePointsRule apr);
        Task<ServiceResponse<List<AccumulatePointsRule>>> GetAllAccumulatePointRule();
        Task<ServiceResponse<List<AccumulatePointsRule>>> SearchAccumulatePointRule(string keyword);
        Task<ServiceResponse<AccumulatePointsRule>> AddNewAccumulatePointsRule(AccumulatePointsRule acc);
    }
}
