using Microsoft.EntityFrameworkCore;
using Quanly.Data;
using Quanly.Models.AccumulatePoints;
using Quanly.Services.ValidPointsService;
using Quanly.ValidationHandling.AccumulatePointsValidation;

namespace Quanly.Services.AccumulatePointsService
{
    public class AccumulatePointsService : IAccumulatePointsService
    {
        private readonly ValidGetAllAccumulatePoints _validGetAllAccumulatePoints;
        private readonly DataContext _dataContext;
        private readonly DeleteAccumulatePoints _deleteAccumulatePoint;

        public AccumulatePointsService(ValidGetAllAccumulatePoints validGetAllAccumulatePoints, 
            DataContext dataContext,
            DeleteAccumulatePoints deleteAccumulatePoint)
        {
            _validGetAllAccumulatePoints = validGetAllAccumulatePoints;
            _dataContext = dataContext;
            _deleteAccumulatePoint = deleteAccumulatePoint;
        }

        public async Task<ServiceResponse<List<AccumulatePoint>>> GetAllAccumulatePoints()
        {
            var validPoint = await _dataContext.AccumulatePoints.OrderByDescending(n => n.Id).ToListAsync();

            var validPointsResult = _validGetAllAccumulatePoints.AccumulatePoints(validPoint);

            if(validPointsResult != "ok")
            {
                return new ServiceResponse<List<AccumulatePoint>>
                {
                    Message = validPointsResult,
                    Success = false
                };

            }
            return new ServiceResponse<List<AccumulatePoint>>
            {
                Data = validPoint,
                Message = "Succesfully",
                Success = true
            };
        }

        public async Task<ServiceResponse<List<AccumulatePoint>>> DeleteAccumulatePoints(int pointId)
        {
            var validPoint = _deleteAccumulatePoint.DeletePoints(pointId);
            if (validPoint != "ok")
            {
                return new ServiceResponse<List<AccumulatePoint>>
                {
                    Message = validPoint,
                    Success = false
                };
            }

            var idPoint = await _dataContext.AccumulatePoints.FirstOrDefaultAsync(c => c.Id == pointId);
            _dataContext.AccumulatePoints.Remove(idPoint);
            await _dataContext.SaveChangesAsync();
            return new ServiceResponse<List<AccumulatePoint>>
            {

                Message = "Delete succesfully",
                Success = true
            };
        }

        
    }
}
