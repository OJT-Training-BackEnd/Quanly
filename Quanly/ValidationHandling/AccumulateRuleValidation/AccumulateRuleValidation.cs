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
        public string ValidateUpdateAccumulateRule(AccumulatePointsRule accupointrule)
        {
            var cardExist = _dataContext.AccumulatePointsRules.FirstOrDefault(x => x.Id == accupointrule.Id);
            if (cardExist == null)
            {
                return "Customer does not exist";
            }
            Regex regex = new Regex(@"[a-z]");
            if (!regex.IsMatch(accupointrule.Name))
            {
                return "Name must be character only";
            }
            var name = _dataContext.AccumulatePointsRules.FirstOrDefault(x => x.Name == accupointrule.Name);
            if (accupointrule == null)
            {
                return "The MemberCard is Empty";
            }
            if(accupointrule.ApplyFrom > accupointrule.ApplyTo)
            {
                return "The Date Apply To must greater than Apply From";
            }
            if (accupointrule.Name.Contains("!") ||  accupointrule.Name.Contains("@")
                || accupointrule.Name.Contains("#") || accupointrule.Name.Contains("$")
                || accupointrule.Name.Contains("%") || accupointrule.Name.Contains("^")
                || accupointrule.Name.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }
            List<string> acceptedFomula = new List<string> {"Loai","Amount","TopupQty", "SinhNhat", "weekday", "hour" };
            int i = 0;
            foreach(string fomula in acceptedFomula)
            {
                if(!accupointrule.Formula.Equals(fomula))
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
