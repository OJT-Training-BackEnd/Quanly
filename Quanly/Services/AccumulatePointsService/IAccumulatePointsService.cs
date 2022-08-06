using Quanly.Models.AccumulatePoints;
using Quanly.Models.MemberCards;

namespace Quanly.Services.ValidPointsService
{
    public interface IAccumulatePointsService
    {
        Task<ServiceResponse<List<AccumulatePoint>>> GetAllAccumulatePoints();

        Task<ServiceResponse<List<AccumulatePoint>>> DeleteAccumulatePoints(int id);

        Task<ServiceResponse<AccumulatePoint>> UpdateAccumulatePoints(AccumulatePoint accumulatePoint, string cardNumber);

        Task<ServiceResponse<AccumulatePoint>> search(string cardNumber);

        Task<ServiceResponse<List<AccumulatePoint>>> searchAccumulatePoints(string keyword);

    }
}
