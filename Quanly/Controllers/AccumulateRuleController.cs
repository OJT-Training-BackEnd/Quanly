using Microsoft.AspNetCore.Mvc;
using Quanly.Models.AccumulatePointsRules;
using Quanly.Services.AccumulateRuleService;

namespace Quanly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccumulateRuleController : ControllerBase
    {
        private readonly IAccumulateRuleService _accumulateRuleService;
        public AccumulateRuleController(IAccumulateRuleService accumulateRuleService)
        {
            _accumulateRuleService = accumulateRuleService;
        }
        [HttpPut("UpdateRule")]
        public async Task<ActionResult<ServiceResponse<AccumulatePointsRule>>> UpdateAccumulatePointRule(AccumulatePointsRule apr)
        {
            return Ok(await _accumulateRuleService.UpdateAccumulatePointsRule(apr));
        }
    }
}
