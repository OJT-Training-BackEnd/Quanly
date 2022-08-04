using Quanly.Models.AccumulatePoints;

namespace Quanly.ValidationHandling.AccumulatePointsValidation
{
    public class ValidGetAllAccumulatePoints
    {
        public string AccumulatePoints(List<AccumulatePoint> points)
        {
            if(points.Count == 0)
                return "This customer have no point left";
            
            return "ok";
            
        }
    }
}
