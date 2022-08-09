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

        public AccumulateRuleService(DataContext context, AccumulateRuleValidation AccumulateRuleValidation, AccumulatePoint accumulatePoint)
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

        public async Task<ServiceResponse<List<AccumulatePointsRule>>> GetAllAccumulatePointRule()
        {

            try
            {
                var list = await _context.AccumulatePointsRules.OrderByDescending(x => x.Id).ToListAsync();
                var validate = _accumulateRuleValidation.ValidateGetAllAccumulatePointRule(list);
                if (validate != "ok")
                {
                    return new ServiceResponse<List<AccumulatePointsRule>>
                    {
                        Message = validate,
                        Success = false
                    };
                }
                return new ServiceResponse<List<AccumulatePointsRule>> { Message = "Successfully", Success = true, Data = list };
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<AccumulatePointsRule>>
                {
                    Message = e.Message,
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<List<AccumulatePointsRule>>> SearchAccumulatePointRule(string keyword)
        {
            try
            {
                var Validate = _accumulateRuleValidation.ValidateSearchAccumulatePointRule(keyword);
                if (Validate != "ok")
                {
                    return new ServiceResponse<List<AccumulatePointsRule>>
                    {
                        Success = false,
                        Message = Validate
                    };
                }
                var apr = _context.AccumulatePointsRules.Where(x => x.Name.Contains(keyword)
                                                                    || x.ApplyFrom.ToString().Contains(keyword)
                                                                    || x.ApplyTo.ToString().Contains(keyword)
                                                                    || x.DateAdded.ToString().Contains(keyword));
                if (apr.Count() == 0)
                {
                    return new ServiceResponse<List<AccumulatePointsRule>>
                    {
                        Success = false,
                        Message = $"Can not find any result {keyword}"
                    };
                }


                return new ServiceResponse<List<AccumulatePointsRule>>
                {
                    Data = await apr.OrderByDescending(n => n.Code).ToListAsync(),
                    Success = true,
                    Message = "Search successfully"
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<AccumulatePointsRule>>
                {
                    Message = e.Message,
                    Success = false
                };
            }

        }

        public async Task<ServiceResponse<AccumulatePointsRule>> UpdateAccumulatePointsRule(AccumulatePointsRule apr)
        {
            var aprule = _accumulateRuleValidation.ValidateUpdateAccumulateRule(apr);
            if (aprule != "ok")
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
        public async Task<ServiceResponse<AccumulatePointsRule>> DeleteAccumulatePointsRule(int accumulatePointsRule)
        {
            var message = _accumulateRuleValidation.ValidDeleteAccumulateRule(accumulatePointsRule);
            if (message != "ok")
            {
                return new ServiceResponse<AccumulatePointsRule>
                {
                    Message = message,
                    Success = false
                };
            }

            var apr = await _context.AccumulatePointsRules.FirstOrDefaultAsync(x => x.Id == accumulatePointsRule);
            _context.AccumulatePointsRules.Remove(apr);
            await _context.SaveChangesAsync();
            return new ServiceResponse<AccumulatePointsRule>
            {

                Message = "Delete succecfully from system",
                Success = true
            };
        }

        public async Task<ServiceResponse<AccumulatePointsRule>> GetAccumulateRuleById(int accumulateRuleId)
        {
            var resultAfterValidate = _accumulateRuleValidation.ValidateAccumulateRuleId(accumulateRuleId);
            if (!resultAfterValidate.Equals("ok"))
            {
                return new ServiceResponse<AccumulatePointsRule>
                {
                    Message = resultAfterValidate,
                    Success = false
                };
            }

            var accumulateRule = await _context.AccumulatePointsRules.FindAsync(accumulateRuleId);
            return new ServiceResponse<AccumulatePointsRule>
            {
                Data = accumulateRule,
                Message = "Get accumulate rule successfully",
                Success = true
            };

        }
    }
}
