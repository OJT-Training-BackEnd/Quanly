using Quanly.Data;
using Quanly.Models.MemberCards;
using System.Text.RegularExpressions;

namespace Quanly.ValidationHandling.MemberCardValidation
{
    public class MemberCardValidation
    {
        private readonly DataContext _context;

        public MemberCardValidation(DataContext context)
        {
            _context = context;
        }
        public string ValidateMemberCard(MemberCard memberCard)
        {
            if (memberCard == null)
                return "The MemberCard is Empty";

            var memberCardExist = _context.MemberCards.FirstOrDefault(x => x.CardNumber == memberCard.CardNumber);
            if (memberCardExist != null)
                return "The CardNumber has existed! Please enter a new card number";

            Regex regex = new Regex(@"^\d{1,10}$");
            if (!regex.IsMatch(memberCard.CardNumber))
                return "Card Numbers must be numbers";

            if (memberCard.CardNumber.Contains("!") || memberCard.CardNumber.Contains("@")
                || memberCard.CardNumber.Contains("#") || memberCard.CardNumber.Contains("$")
                || memberCard.CardNumber.Contains("%") || memberCard.CardNumber.Contains("^")
                || memberCard.CardNumber.Contains("Select * "))
                return "Please do not enter special character or sql query";

            if (memberCard.IssueDate > memberCard.EffectDate)
                return "The issue date needs to be less than the effective date";

            if (memberCard.ValidDate < memberCard.EffectDate)
                return "The effect date needs to be greater than the valid date";

            var cardExpiration = 1;
            if ((memberCard.ValidDate?.Year - memberCard.EffectDate?.Year) < cardExpiration)
                return "The validity period of the card must be greater than or equal to 1";

            return "ok";
        }

        public string ValidateMemberCardWhenUpdate(MemberCard memberCard)
        { 
            var cardExist = _context.MemberCards.FirstOrDefault(x => x.Id == memberCard.Id);
            if (cardExist == null)
                return "Customer does not exist";

            Regex regex = new Regex(@"^\d{1,10}$");
            if (!regex.IsMatch(memberCard.CardNumber))
                return "Card Numbers must be numbers";

            if (memberCard == null)
                return "The MemberCard is Empty";

            var memberCardExist = _context.MemberCards.FirstOrDefault(x => x.CardNumber == memberCard.CardNumber);
            if (memberCardExist != null)
                return "The CardNumber has existed! Please enter a new card number";

            if (memberCard.CardNumber.Contains("!") || memberCard.CardNumber.Contains("@")
                || memberCard.CardNumber.Contains("#") || memberCard.CardNumber.Contains("$")
                || memberCard.CardNumber.Contains("%") || memberCard.CardNumber.Contains("^")
                || memberCard.CardNumber.Contains("Select * "))
                return "Please do not enter special character or sql query";

            if (memberCard.IssueDate > memberCard.EffectDate)
                return "The issue date needs to be less than the effective date";

            if (memberCard.ValidDate < memberCard.EffectDate)
                return "The effect date needs to be greater than the valid date";

            var cardExpiration = 1;
            if ((memberCard.ValidDate?.Year - memberCard.EffectDate?.Year) < cardExpiration)
                return "The validity period of the card must be greater than or equal to 1";

            return "ok";
        }

        public string ValidateSearchMemberCard(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return "Please enter the keyword to search";
            if (keyword.Count() > 50)
                return "The keyword is out of range";
            return "ok";
        }
        public string ValidateChangeStatusCard(int id)
        {
            var membercard = _context.MemberCards.FirstOrDefault(x => x.Id == id);
            if (membercard == null)
                return $"Can not see the member card of this id : {id}";
            return "ok";
        }
        public string ValidGetMemberList(List<MemberCard> memberCard)
        {
            if(memberCard == null)
            {
                return "The customer list is empty";
            }
            return "ok";
        }
        public string ValidDeleteMember(int id)
        {
            var memberCardExist = _context.MemberCards.FirstOrDefault(x => x.Id == id);
            if (memberCardExist == null)
            {
                return "The MemberCard is empty";
            }
             var point= _context.AccumulatePoints.FirstOrDefault(x => x.MemberCards == memberCardExist);
            if (point != null)
            {
                return "The MemberCard has a point, Cant Delete";
            }
           return "ok";

        }
    }
}
