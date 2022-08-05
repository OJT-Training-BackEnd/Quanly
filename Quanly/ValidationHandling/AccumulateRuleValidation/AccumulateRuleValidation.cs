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

            if(acc.Name.Count() > 20)
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

            if (string.IsNullOrEmpty(acc.Guide))
                return "Please enter the Guide";

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
            
            if (string.IsNullOrEmpty(accupointrule.Code))
                return "Please enter the code";

            if (accupointrule.Code.Count() > 10)
                return "Please enter the code less than 10";
            if (accupointrule.Code.Contains("!") || accupointrule.Code.Contains("@")
                || accupointrule.Code.Contains("#") || accupointrule.Code.Contains("$")
                || accupointrule.Code.Contains("%") || accupointrule.Code.Contains("^")
                || accupointrule.Code.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }
            var codeExist = _dataContext.AccumulatePointsRules.FirstOrDefault(x => x.Code == accupointrule.Code);
            if (codeExist != null)
                return "The AccumulateRule Code has duplicate";

            if (string.IsNullOrEmpty(accupointrule.Name))
                return "Please enter the Name";

            if (accupointrule.Name.Count() > 20)
                return "Please enter the Name less than 20 characters";
            var name = _dataContext.AccumulatePointsRules.FirstOrDefault(x => x.Name == accupointrule.Name);
            if (accupointrule == null)
            {
                return "The MemberCard is Empty";
            }
            if(accupointrule.ApplyFrom >= accupointrule.ApplyTo)
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

            List<string> acceptedFomula = new List<string> {"Loai","Amount","TopupQty", "SinhNhat", "weekday", "hour" };
            int i = 0;
            foreach(string fomula in acceptedFomula)
            {
                if(!accupointrule.Formula.ToLower().Equals(fomula.ToLower()))
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
            if(apr == null)
            {
                return "The Accumulate Point Rule is empty";
            }
            return "ok";
        }
        public string ValidateSearchAccumulatePointRule (string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return "Please enter the keyword to search";
            if (keyword.Count() > 50)
                return "The keyword is out of range";
            return "ok";
        }
    }
}
