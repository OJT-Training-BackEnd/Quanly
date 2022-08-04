using Microsoft.EntityFrameworkCore;
using Quanly.Data;
using Quanly.Models.AccumulatePointsRules;
using Quanly.ValidationHandling.AccumulateRuleValidation;

namespace Quanly.Services.AccumulateRuleService
{
    public class AccumulateRuleService : IAccumulateRuleService
    {
        private readonly DataContext _context;
        private readonly AccumulateRuleValidation _accumulateRuleValidation;

        public AccumulateRuleService (DataContext context, AccumulateRuleValidation AccumulateRuleValidation)
        {
            _context = context;
            _accumulateRuleValidation = AccumulateRuleValidation;
        }

        public async Task<ServiceResponse<AccumulatePointsRule>> UpdateAccumulatePointsRule(AccumulatePointsRule apr)
        {
            var aprule = _accumulateRuleValidation.ValidateUpdateAccumulateRule(apr);
            if(aprule != "ok")
            {
                return new ServiceResponse<AccumulatePointsRule>
                {
                    Success = false,
                    Message = aprule
                };
            }
            var aprExits = await _context.AccumulatePointsRules.FirstOrDefaultAsync(x => x.Id == apr.Id);
            aprExits.ApplyFrom = apr.ApplyFrom;
            aprExits.ApplyTo = apr.ApplyTo;
            aprExits.Formula = apr.Formula;
            aprExits.Note = apr.Note;
            aprExits.Name = apr.Name;
            await _context.SaveChangesAsync();
            return new ServiceResponse<AccumulatePointsRule>
            {
                Success = true,
                Message = "Updated Successfully"
            };
        }
    }
}
