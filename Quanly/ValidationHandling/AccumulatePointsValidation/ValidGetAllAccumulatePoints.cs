using Microsoft.EntityFrameworkCore;
using Quanly.Data;
using Quanly.Models.AccumulatePoints;

namespace Quanly.ValidationHandling.AccumulatePointsValidation
{
    public class ValidGetAllAccumulatePoints
    {
        private readonly DataContext _dataContext;

        public ValidGetAllAccumulatePoints(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public string AccumulatePoints(List<AccumulatePoint> points)
        {
            if (points.Count == 0)
                return "This customer have no point left";
            return "ok";

        }
        public string ValidateCreateAccumulatePoint(AccumulatePoint accumulatePoint)
        {
            if (accumulatePoint == null)
                return "The AccumulatePoint is empty";
            if (accumulatePoint.MemberCards?.ValidDate < DateTime.Now)
                return "The date is not suitable";
            if (string.IsNullOrEmpty(accumulatePoint.Reason))
                return "Please enter the rease";
            if (accumulatePoint.Reason.Count() > 100)
                return "Please enter reason less than 100";
            return "Ok";
        }
 
        public string checkValidateUpdateAccummulatePoint(AccumulatePoint accumulatePoint, int id)
        {
            if (id == null || id == 0)
            {
                return "Id can not be null";
            }
            var _accumulatePoint =  _dataContext.AccumulatePoints.Include(x => x.MemberCards).FirstOrDefault(x => x.Id == id);
            if (_accumulatePoint == null)
            {
                return "Accumulate Point has null";
            }
            var _membercard =  _dataContext.MemberCards.Include(x => x.Customer)
                    .FirstOrDefault(x => x.CardNumber == _accumulatePoint.MemberCards.CardNumber);
            if (_membercard == null)
            {
                return "Member card not existed";
            }
            if (accumulatePoint.MemberCards.ValidDate < DateTime.Now)
                return "The date is not suitable";
            if (string.IsNullOrEmpty(accumulatePoint.Reason))
                return "Please enter the rease";
            if (accumulatePoint.Reason.Count() > 100)
                return "Please enter reason less than 100";
            
            return "Ok";
        }

        public string ValidateAccumulatePointId(int? accumulatePointId)
        {
            try
            {
                if (accumulatePointId == null)
                    return "Please enter accumulate point id";

                var accumulatePoint = _dataContext.AccumulatePoints.Find(accumulatePointId);
                if (accumulatePoint == null)
                    return "This transaction is not exist";
            }
            catch (System.Exception ex)
            {
                ex.Message.ToString();
            }
            return "ok";
        }
    }
}
