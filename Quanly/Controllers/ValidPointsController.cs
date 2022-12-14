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
        private readonly IAccumulatePointsService _AccumulatePointsService;

        public ValidPointsController(IAccumulatePointsService accumulatePointsService)
        {
            _AccumulatePointsService = accumulatePointsService;
        }

        [HttpGet("GetAccumulatePointList")]

        public async Task<ActionResult<ServiceResponse<List<AccumulatePoint>>>> GetAllCustomer()
        {
            return Ok(await _AccumulatePointsService.GetAllAccumulatePoints());
        }

        [HttpDelete("DeleteAccumulatePoint/{id}")]
        public async Task<ActionResult<ServiceResponse<List<AccumulatePoint>>>> DeletePoint(int id)
        {
            return Ok(await _AccumulatePointsService.DeleteAccumulatePoints(id));
        }

        [HttpPut("UpdateAccumulatePoint")]
        public async Task<ActionResult<ServiceResponse<AccumulatePoint>>> UpdatePoint(AccumulatePoint accumulatePoint)
        {
            return Ok(await _AccumulatePointsService.UpdateAccumulatePoints(accumulatePoint));
        }

        /*[HttpGet("SearchAccumulatePoint/{cardNumber}")]

        public async Task<ActionResult<ServiceResponse<AccumulatePoint>>> SearchCardNumber(string cardnumber)
        {
            return Ok(await _AccumulatePointsService.search(cardnumber));
        }*/

        [HttpGet("SearchAccumulatePoint")]
        public async Task<ActionResult<ServiceResponse<AccumulatePoint>>> searchAccumulatePoints(string keyword)
        {
            return Ok(await _AccumulatePointsService.searchAccumulatePoints(keyword));
        }
        [HttpPost("CreateAccumulatePoint")]
        public async Task<ActionResult<ServiceResponse<AccumulatePoint>>> CreateAccumulatePoint(AccumulatePoint accumulatePoint)
        {
            return Ok(await _AccumulatePointsService.CreateAccumulatePoint(accumulatePoint));
        }

        [HttpGet("GetPointById/{id}")]
        public async Task<ActionResult<ServiceResponse<AccumulatePoint>>> GetPointById(int id)
        {
            return Ok(await _AccumulatePointsService.GetAccumulatePointById(id));
        }

    }
}
