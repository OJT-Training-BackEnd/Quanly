using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quanly.Models.AccumulatePoints;
using Quanly.Services.ValidPointsService;

namespace Quanly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidPointsController : ControllerBase
    {
        private readonly IAccumulatePointsService _validpointsService;

        public ValidPointsController(IAccumulatePointsService validpointsService)
        {
            _validpointsService = validpointsService;
        }

        [HttpGet("GetAccumulatePointList")]

        public async Task<ActionResult<ServiceResponse<List<AccumulatePoint>>>> GetAllCustomer()
        {
            return Ok(await _validpointsService.GetAllAccumulatePoints());
        }

        [HttpDelete("DeleteAccumulatePoint")]
        public async Task<ActionResult<ServiceResponse<List<AccumulatePoint>>>> DeletePoint(int Id)
        {
            return Ok(await _validpointsService.DeleteAccumulatePoints(Id));
        }
        /*
                [HttpPut("UpdateAccumulatePoint/{cardNumber}")]

                public async Task<ActionResult<ServiceResponse<AccumulatePoint>>> UpdatePoint(AccumulatePoint accumulatePoint , string cardNumber)
                {
                    return Ok(await _validpointsService.UpdateAccumulatePoints(accumulatePoint,cardNumber));
                }*/

        [HttpGet("SearchAccumulatePoint/{cardNumber}")]

        public async Task<ActionResult<ServiceResponse<AccumulatePoint>>> SearchCardNumber(string cardnumber)
        {
            return Ok(await _validpointsService.search(cardnumber));
        }

        [HttpGet("SearchAccumulatePoint")]
        public async Task<ActionResult<ServiceResponse<AccumulatePoint>>> searchAccumulatePoints(string keyword)
        {
            return Ok(await _validpointsService.searchAccumulatePoints(keyword));
        }
    }
}
