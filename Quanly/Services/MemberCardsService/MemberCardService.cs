using Microsoft.EntityFrameworkCore;
using Quanly.Data;
using Quanly.Models.MemberCards;
using Quanly.ValidationHandling.MemberCardValidation;
using System.Security.Claims;

namespace Quanly.Services.MemberCardsService
{
    public class MemberCardService : IMemberCardService
    {
        private readonly DataContext _context;
        private readonly MemberCardValidation _memberCardValidation;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MemberCardService(DataContext context,MemberCardValidation memberCardValidation, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _memberCardValidation = memberCardValidation;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ServiceResponse<MemberCard>> AddNewMemberCard(MemberCard memberCard)
        {
            var cardValidate = _memberCardValidation.ValidateMemberCard(memberCard);
            if (cardValidate != "ok")
            {
                return new ServiceResponse<MemberCard>
                {
                    Success = false,
                    Message = cardValidate
                };
            }
            /*var importer = await _context.User.FindAsync(GetUserId());
            memberCard.Importer = importer.Username;*/
            await _context.MemberCards.AddAsync(memberCard);
            await _context.SaveChangesAsync();
            return new ServiceResponse<MemberCard>
            {
                Success = true,
                Message = "Added Successfully"
            };
        }

        public async Task<ServiceResponse<List<MemberCard>>> DeleteMemberCard(int id)
        {
            var cardValidate = _memberCardValidation.ValidDeleteMember(id);
            if(cardValidate != "ok")
            {
                return new ServiceResponse<List<MemberCard>>
                {
                    Success = false,
                    Message = cardValidate
                };
            }
            var member = await _context.MemberCards.FirstOrDefaultAsync(x => x.Id == id);
            _context.MemberCards.Remove(member);
            await _context.SaveChangesAsync();
            return new ServiceResponse<List<MemberCard>>
            {
                Message = "Delete Successfully",
                Success = true
            };
        }
        public async Task<ServiceResponse<List<MemberCard>>> GetAllMemberCards()
        {
            var membercard = await _context.MemberCards.OrderByDescending(x => x.Id).ToListAsync();
            var validateResult = _memberCardValidation.ValidGetMemberList(membercard);
            if (validateResult != "ok")
            {
                return new ServiceResponse<List<MemberCard>>
                {
                    Message = validateResult,
                    Success = false,

                };
            }
            return new ServiceResponse<List<MemberCard>> { Data=membercard, Message="Successfully", Success = true };
        }

        public async Task<ServiceResponse<MemberCard>> UpdateMemberCard(MemberCard newMemberCard)
        {
            var cardValidate = _memberCardValidation.ValidateMemberCardWhenUpdate(newMemberCard);
            if (cardValidate != "ok")
            {
                return new ServiceResponse<MemberCard>
                {
                    Success = false,
                    Message = cardValidate
                };
            }
            var cardExits = await _context.MemberCards.FirstOrDefaultAsync(x => x.Id == newMemberCard.Id);
            cardExits.CardNumber = newMemberCard.CardNumber;
            cardExits.Reason = newMemberCard.Reason;
            cardExits.IssueDate = newMemberCard.IssueDate;
            cardExits.EffectDate = newMemberCard.EffectDate;
            cardExits.ValidDate = newMemberCard.ValidDate;
            cardExits.IsActive = newMemberCard.IsActive;
            /*var importer = await _context.User.FindAsync(GetUserId());
            cardExits.Importer = importer.Username;*/

            await _context.SaveChangesAsync();
            return new ServiceResponse<MemberCard>
            {
                Success = true,
                Message = "Updated Successfully"
            };
        }

        // Get authenticated USER
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
        .FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
