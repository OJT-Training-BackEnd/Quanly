using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quanly.Models.MemberCards;
using Quanly.Services.MemberCardsService;

namespace Quanly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberCardController : ControllerBase
    {
        private readonly IMemberCardService _memberCardService;

        public MemberCardController(IMemberCardService memberCardService)
        {
            _memberCardService = memberCardService;
        }
        [HttpPost("AddMemberCard")]
        public async Task<ActionResult<ServiceResponse<MemberCard>>> AddNewMemberCard(MemberCard memberCard)
        {
            return Ok(await _memberCardService.AddNewMemberCard(memberCard));
        }
    }
}
