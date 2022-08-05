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

        public AccumulateRuleService(DataContext context, AccumulateRuleValidation AccumulateRuleValidation)
        {
            _context = context;
            _accumulateRuleValidation = AccumulateRuleValidation;
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
            catch(Exception e)
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
                                                                    || x.Note.ToLower().Contains(keyword.ToLower())
                                                                    || x.ApplyTo.ToString().Contains(keyword)
                                                                    || x.Guide.ToLower().Contains(keyword)
                                                                    || x.DateAdded.ToString().Contains(keyword)
                                                                    || x.Formula.ToLower().Contains(keyword.ToLower())
                                                                    || x.Code.ToLower().Contains(keyword.ToLower())
                                                                    || x.Importer.ToLower().Contains(keyword.ToLower()));
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
            }catch(Exception e)
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
