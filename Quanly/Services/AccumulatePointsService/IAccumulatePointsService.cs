using Quanly.Models.AccumulatePoints;
using Quanly.Models.Customers;
using Quanly.Models.MemberCards;

namespace Quanly.Services.ValidPointsService
{
    public interface IAccumulatePointsService
    {
        Task<ServiceResponse<List<AccumulatePoint>>> GetAllAccumulatePoints();
        Task<ServiceResponse<List<AccumulatePoint>>> DeleteAccumulatePoints(int id);
        Task<ServiceResponse<AccumulatePoint>> UpdateAccumulatePoints(AccumulatePoint accumulatePoint);
        Task<ServiceResponse<AccumulatePoint>> search(string cardNumber);
        Task<ServiceResponse<List<AccumulatePoint>>> searchAccumulatePoints(string keyword);
        Task<ServiceResponse<AccumulatePoint>> CreateAccumulatePoint(AccumulatePoint accumulatePoint);
        Task<ServiceResponse<AccumulatePoint>> GetAccumulatePointById(int accumulatePointId);

    }
}
