using Quanly.Models.AccumulatePoints;

namespace Quanly.Services.ValidPointsService
{
    public interface IAccumulatePointsService
    {
        Task<ServiceResponse<List<AccumulatePoint>>> GetAllAccumulatePoints();

        Task<ServiceResponse<List<AccumulatePoint>>> DeleteAccumulatePoints(int id);
    }
}
