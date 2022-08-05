using Microsoft.EntityFrameworkCore;
using Quanly.Data;
using Quanly.Models.AccumulatePoints;
using Quanly.Models.AccumulatePointsRules;
using Quanly.ValidationHandling.AccumulateRuleValidation;

namespace Quanly.Services.AccumulateRuleService
{
    public class AccumulateRuleService : IAccumulateRuleService
    {
        private readonly DataContext _context;
        private readonly AccumulateRuleValidation _accumulateRuleValidation;
        private readonly AccumulatePoint _accumulatePoint;

        public AccumulateRuleService (DataContext context, AccumulateRuleValidation AccumulateRuleValidation, AccumulatePoint accumulatePoint)
        {
            _context = context;
            _accumulateRuleValidation = AccumulateRuleValidation;
            _accumulatePoint = accumulatePoint;
        }

        public async Task<ServiceResponse<AccumulatePointsRule>> AddNewAccumulatePointsRule(AccumulatePointsRule acc)
        {
            var validate = _accumulateRuleValidation.ValidateAddNewAccumulateRule(acc);
            if (validate != "ok")
            {
                return new ServiceResponse<AccumulatePointsRule>
                {
                    Success = false,
                    Message = validate
                };
            }
            await _context.AccumulatePointsRules.AddAsync(acc);
            await _context.SaveChangesAsync();
            return new ServiceResponse<AccumulatePointsRule>
            {
                Data = acc,
                Success = true,
                Message = "Added Successfully"
            };
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
            aprExits.Code = apr.Code;
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
