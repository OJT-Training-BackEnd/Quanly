using Quanly.Models.MemberCards;

namespace Quanly.Services.MemberCardsService
{
    public interface IMemberCardService
    {
        Task<ServiceResponse<MemberCard>> AddNewMemberCard(MemberCard memberCard);
        Task<ServiceResponse<MemberCard>> UpdateMemberCard(MemberCard memberCard);
    }
}
