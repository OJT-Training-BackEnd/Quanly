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
        public string checkValidateUpdateAccummulatePoint(AccumulatePoint accumulatePoint, string cardNumber)
        {
            if (cardNumber == null)
            {
                return "Cart Number must not be null";
            }
            var _memberCard = _dataContext.MemberCards.Include(x => x.Customer).FirstOrDefaultAsync(x => x.CardNumber == accumulatePoint.MemberCards.CardNumber);
            if (_memberCard == null)
            {
                return "Member card not existed";

            }

            if (cardNumber.Contains("!") || cardNumber.Contains("@")
                || cardNumber.Contains("#") || cardNumber.Contains("$")
                || cardNumber.Contains("%") || cardNumber.Contains("^")
                || cardNumber.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }
            if (accumulatePoint.MemberCards.ValidDate < DateTime.Now)
                return "The date is not suitable";
            if (string.IsNullOrEmpty(accumulatePoint.Reason))
                return "Please enter the rease";
            if (accumulatePoint.Reason.Count() > 100)
                return "Please enter reason less than 100";


            return "ok";
        }
    }
}
