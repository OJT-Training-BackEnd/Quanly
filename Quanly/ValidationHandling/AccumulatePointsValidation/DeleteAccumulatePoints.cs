using Quanly.Data;

namespace Quanly.ValidationHandling.AccumulatePointsValidation
{
    public class DeleteAccumulatePoints
    {
        private readonly DataContext _dataContext;

        public DeleteAccumulatePoints(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public string DeletePoints (int id)
        {
            var validId = _dataContext.AccumulatePoints.FirstOrDefault(x => x.Id == id);

             if(validId == null )
            {
                return "This customer does not existed";
            }
            return "ok";
        }

    }
}
