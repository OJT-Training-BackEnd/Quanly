using Quanly.Models.MemberCards;

namespace Quanly.Services.MemberCardsService
{
    public interface IMemberCardService
    {
        Task<ServiceResponse<MemberCard>> AddNewMemberCard(MemberCard memberCard);
        Task<ServiceResponse<MemberCard>> UpdateMemberCard(MemberCard newMemberCard);
        Task<ServiceResponse<List<MemberCard>>> GetAllMemberCards();
        Task<ServiceResponse<List<MemberCard>>> DeleteMemberCard(int Cardnumber);
    }
}
