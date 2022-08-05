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
        public string ValidateCreateAccumulatePoint(AccumulatePoint accumulatePoint)
        {
            if (accumulatePoint == null)
                return "The AccumulatePoint is empty";
            if (accumulatePoint.MemberCards.ValidDate < DateTime.Now)
                return "The date is not suitable";
            if (string.IsNullOrEmpty(accumulatePoint.Reason))
                return "Please enter the rease";
            if (accumulatePoint.Reason.Count() > 100)
                return "Please enter reason less than 100";
            return "Ok";
        }
    }
}
