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

        public MemberCardService(DataContext context, MemberCardValidation memberCardValidation, IHttpContextAccessor httpContextAccessor)
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


        public async Task<ServiceResponse<string>> ChangeStatusCard(int id)
        {
            var idValidate = _memberCardValidation.ValidateChangeStatusCard(id);
            if (idValidate != "ok")
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = idValidate
                };
            }
            await SwapStatus(id);
            await _context.SaveChangesAsync();
            return new ServiceResponse<string>
            {
                Success = true,
                Message = "Changed Successfully"
            };
        }

        private async Task SwapStatus(int id)
        {
            var memberCard = await _context.MemberCards.FirstOrDefaultAsync(x => x.Id == id);
            if (memberCard.IsActive == true)
            {
                memberCard.IsActive = false;
            }
            else
            {
                memberCard.IsActive = true;
            }
        }

        public async Task<ServiceResponse<List<MemberCard>>> SearchMemberCard(string keyword)
        {
            var cardValidate = _memberCardValidation.ValidateSearchMemberCard(keyword);
            if (cardValidate != "ok")
            {
                return new ServiceResponse<List<MemberCard>>
                {
                    Success = false,
                    Message = cardValidate
                };
            }
            IQueryable<MemberCard> memberCards = SearchMemberCardByAllField(keyword);
            if (memberCards.Count() == 0)
            {
                return new ServiceResponse<List<MemberCard>>
                {
                    Success = false,
                    Message = $"Can not find any result {keyword}"
                };
            }


            return new ServiceResponse<List<MemberCard>>
            {
                Data = await memberCards.OrderByDescending(n => n.Id).ToListAsync(),
                Success = true,
                Message = "Search successfully"
            };
        }

        private IQueryable<MemberCard> SearchMemberCardByAllField(string keyword)
        {
            return _context.MemberCards.Where(x => x.CardNumber.Contains(keyword)
                                                                || x.IssueDate.ToString().Contains(keyword)
                                                                || x.Reason.ToLower().Contains(keyword.ToLower())
                                                                || x.EffectDate.ToString().Contains(keyword)
                                                                || x.ValidDate.ToString().Contains(keyword)
                                                                || x.Customer.CustomerName.ToLower().Contains(keyword.ToLower())
                                                                || x.RegisterAt.ToLower().Contains(keyword.ToLower())
                                                                || x.Importer.ToLower().Contains(keyword.ToLower()));
        }

        public async Task<ServiceResponse<List<MemberCard>>> DeleteMemberCard(int id)
        {
            var cardValidate = _memberCardValidation.ValidateDeleteMember(id);
            if (cardValidate != "ok")
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
            var validateResult = _memberCardValidation.ValidateGetMemberList(membercard);
            if (validateResult != "ok")
            {
                return new ServiceResponse<List<MemberCard>>
                {
                    Message = validateResult,
                    Success = false,

                };
            }
            return new ServiceResponse<List<MemberCard>> { Data = membercard, Message = "Successfully", Success = true };

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
            cardExits.Note = newMemberCard.Note;
            await _context.SaveChangesAsync();
            return new ServiceResponse<MemberCard>
            {
                Success = true,
                Message = "Updated Successfully"
            };
        }


        public async Task<ServiceResponse<MemberCard>> SearchMemberCardToAddPoint(string cardNumber)
        {
            var validate = _memberCardValidation.ValidateSearchCardToAddPoint(cardNumber);
            if (validate != "ok")
            {
                return new ServiceResponse<MemberCard>
                {
                    Success = false,
                    Message = validate
                };
            }
            var res = await _context.MemberCards
                            .Include(x => x.Customer)
                            .FirstOrDefaultAsync(x => x.CardNumber == cardNumber);
            return new ServiceResponse<MemberCard>
            {
                Data = res,
                Success = true,
                Message = "Find Successfully"
            };

        }

        public async Task<ServiceResponse<MemberCard>> GetMemberCardById(int memberCardId)
        {
            var resultAfterValidate = _memberCardValidation.ValidateMemberCardId(memberCardId);
            if (!resultAfterValidate.Equals("ok"))
            {
                return new ServiceResponse<MemberCard>
                {
                    Success = false,
                    Message = resultAfterValidate
                };
            }

            var memberCard = await _context.MemberCards.FindAsync(memberCardId);

            return new ServiceResponse<MemberCard>
            {
                Data = memberCard,
                Success = true,
                Message = "Get member card info successfully"
            };
        }

    }
}
