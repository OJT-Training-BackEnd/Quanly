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

        [HttpGet("GetAllAccumulateRule")]
        public async Task<ActionResult<ServiceResponse<AccumulatePointsRule>>> GetAllRule()
        {
            return Ok(await _accumulateRuleService.GetAllAccumulatePointRule());
        }

        [HttpGet("SearchAccumulatePointRule")]
        public async Task<ActionResult<ServiceResponse<AccumulatePointsRule>>> SearchAccumulatePointRule(string keyword)
        {
            return Ok(await _accumulateRuleService.SearchAccumulatePointRule(keyword));

        }

        [HttpPost("AddNewAcumulateRule")]
        public async Task<ActionResult<ServiceResponse<AccumulatePointsRule>>> AddNewAccmulatePointRule(AccumulatePointsRule acc)
        {
            return Ok(await _accumulateRuleService.AddNewAccumulatePointsRule(acc));
        }

        [HttpDelete("DeleteAccumulateRule")]
        public async Task<ActionResult<ServiceResponse<AccumulatePointsRule>>> DeleteAccumulatePointsRule(int id)
        {
            return Ok(await _accumulateRuleService.DeleteAccumulatePointsRule(id));
        }

        [HttpGet("GetAccumulateRuleById/{accumulateRuleId}")]
        public async Task<ActionResult<ServiceResponse<AccumulatePointsRule>>> GetAccumulateRuleById(int accumulateRuleId)
        {
            return Ok(await _accumulateRuleService.GetAccumulateRuleById(accumulateRuleId));
        }
    }
}
