using Quanly.Data;
using Quanly.Models.AccumulatePointsRules;
using System.Text.RegularExpressions;

namespace Quanly.ValidationHandling.AccumulateRuleValidation
{
    public class AccumulateRuleValidation
    {
        private readonly DataContext _dataContext;
        public AccumulateRuleValidation(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public string ValidateAccumulateRuleId(int? accumulateRuleId)
        {
            try
            {
                if(accumulateRuleId == null)
                    return "Please enter accumulate rule Id";
                
                var accumulateRule = _dataContext.AccumulatePointsRules.FirstOrDefault(x => x.Id == accumulateRuleId);
                if(accumulateRule == null)
                    return "This accumulate rule is not exist";

            }
            catch (System.Exception ex)
            {
                return ex.Message.ToString();
            }

            return "ok";
        }

        public string ValidateAddNewAccumulateRule(AccumulatePointsRule acc)
        {
            if (acc == null)
                return "The AccumulateRule is empty";

            if (string.IsNullOrEmpty(acc.Code))
                return "Please enter the code";

            if (acc.Code.Count() > 10)
                return "Please enter the code less than 10";

            if (acc.Code.Contains("!") || acc.Code.Contains("@")
                || acc.Code.Contains("#") || acc.Code.Contains("$")
                || acc.Code.Contains("%") || acc.Code.Contains("^")
                || acc.Code.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }

            var codeExist = _dataContext.AccumulatePointsRules.FirstOrDefault(x => x.Code == acc.Code);
            if (codeExist != null)
                return "The AccumulateRule Code has duplicate";

            if (string.IsNullOrEmpty(acc.Name))
                return "Please enter the Name";

            if (acc.Name.Count() > 20)
                return "Please enter the Name less than 20 characters";

            if (acc.Name.Contains("!") || acc.Name.Contains("@")
                || acc.Name.Contains("#") || acc.Name.Contains("$")
                || acc.Name.Contains("%") || acc.Name.Contains("^")
                || acc.Name.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }

            if (acc.ApplyTo <= acc.ApplyFrom)
                return "The ApplyTo date must be greater than ApplyFrom date";


            if (string.IsNullOrEmpty(acc.Formula))
                return "Please enter the Formula";

            List<string> acceptedFomula = new List<string> { "Loai", "Amount", "TopupQty", "SinhNhat", "weekday", "hour" };
            int i = 0;
            foreach (string fomula in acceptedFomula)
            {
                if (!acc.Formula.ToLower().Equals(fomula.ToLower()))
                {
                    i++;
                }
            }
            if (i == 6)
            {
                return "Fomula is not valid";
            }

            if (string.IsNullOrEmpty(acc.Note))
                return "Please enter the note";

            return "ok";
        }
        public string ValidateUpdateAccumulateRule(AccumulatePointsRule accupointrule)
        {

            if (string.IsNullOrEmpty(accupointrule.Name))
                return "Please enter the Name";

            if (accupointrule.Name.Count() > 20)
                return "Please enter the Name less than 20 characters";
            var name = _dataContext.AccumulatePointsRules.FirstOrDefault(x => x.Name == accupointrule.Name);
            if (accupointrule == null)
            {
                return "The MemberCard is Empty";
            }
            if (accupointrule.ApplyFrom >= accupointrule.ApplyTo)
            {
                return "The Date Apply To must greater than Apply From";
            }
            if (accupointrule.Name.Contains("!") || accupointrule.Name.Contains("@")
                || accupointrule.Name.Contains("#") || accupointrule.Name.Contains("$")
                || accupointrule.Name.Contains("%") || accupointrule.Name.Contains("^")
                || accupointrule.Name.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }

            if (string.IsNullOrEmpty(accupointrule.Formula))
                return "Please enter the Formula";

            List<string> acceptedFomula = new List<string> { "Loai", "Amount", "TopupQty", "SinhNhat", "weekday", "hour" };
            int i = 0;
            foreach (string fomula in acceptedFomula)
            {
                if (!accupointrule.Formula.ToLower().Equals(fomula.ToLower()))
                {
                    i++;
                }
            }
            if (i == 6)
            {
                return "Fomula is not valid";
            }
            return "ok";
        }

        public string ValidateGetAllAccumulatePointRule(List<AccumulatePointsRule> apr)
        {
            if (apr.Count == 0)
            {
                return "The Accumulate Point Rule is empty";
            }
            return "ok";
        }
        public string ValidateSearchAccumulatePointRule(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return "Please enter the keyword to search";
            if (keyword.Count() > 50)
                return "The keyword is out of range";
            return "ok";
        }
        public string ValidDeleteAccumulateRule(int accumulatePointId)
        {
            var accuPoint = _dataContext.AccumulatePointsRules.FirstOrDefault(x => x.Id == accumulatePointId);

            if (accuPoint == null)
            {
                return "This customer's accumulate rule does not existed";
            }

            var accumulatePoint = _dataContext.AccumulatePoints.FirstOrDefault(x => x.AccumulatePointsRules.Id == accuPoint.Id);
            if (accumulatePoint != null)
            {
                return "This accumulate rule has been used so you cant delete";
            }
            return "ok";
        }
    }
}
