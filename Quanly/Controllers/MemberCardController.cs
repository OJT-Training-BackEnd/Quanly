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
        [HttpPut("UpdateMemberCard")]
        public async Task<ActionResult<ServiceResponse<MemberCard>>> UpdateMemberCard(MemberCard newMemberCard)
        {
            return Ok(await _memberCardService.UpdateMemberCard(newMemberCard));
        }

        [HttpGet("SearchMemberCard/{keyword}")]
        public async Task<ActionResult<ServiceResponse<List<MemberCard>>>> SearchMemberCard(string keyword)
        {
            return Ok(await _memberCardService.SearchMemberCard(keyword));
        }
        [HttpPut("ChangedStatusCard/{id}")]
        public async Task<ActionResult<ServiceResponse<string>>> ChangedStatusCard(int id)
        {
            return Ok(await _memberCardService.ChangeStatusCard(id));
        }

        [HttpGet("GetAllMembers")]
        public async Task<ActionResult<ServiceResponse<List<MemberCard>>>> GetAllMembers()
        {
            return Ok(await _memberCardService.GetAllMemberCards());
        }
        [HttpDelete("DeleteMembersCard/{id}")]
        public async Task<ActionResult<ServiceResponse<List<MemberCard>>>> DeleteMembersCard(int id)
        {
            return Ok(await _memberCardService.DeleteMemberCard(id));
        }
        [HttpGet("SearchMemberCardToAddPoint/{cardNumber}")]
        public async Task<ActionResult<ServiceResponse<MemberCard>>> SearchMemberCardToAddPoint(string cardNumber)
        {
            return Ok(await _memberCardService.SearchMemberCardToAddPoint(cardNumber));
        }

        [HttpGet("GetMemberCardById/{memberCardId}")]
        public async Task<ActionResult<ServiceResponse<MemberCard>>> GetMemberCardById(int memberCardId)
        {
            return Ok(await _memberCardService.GetMemberCardById(memberCardId));
        }
    }
}
