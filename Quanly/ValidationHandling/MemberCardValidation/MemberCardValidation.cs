using Microsoft.EntityFrameworkCore;
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

            if (string.IsNullOrEmpty(memberCard.CardNumber))
                return "Please enter CardNumber";

            if (string.IsNullOrEmpty(memberCard.Reason))
                return "Please enter Reason";

            if (memberCard.CardNumber.Count() > 10)
                return "The CardNumber must have less than 10 characters";

            if (memberCard.Reason.Count() > 20)
                return "The reason must have less than 20 charaters";

            Regex regex = new Regex(@"^\d{1,10}$");
            if (!regex.IsMatch(memberCard.CardNumber))
                return "CardNumber must be a number and not more than 10 characters";


            if (memberCard.CardNumber.Contains("!") || memberCard.CardNumber.Contains("@")
                || memberCard.CardNumber.Contains("#") || memberCard.CardNumber.Contains("$")
                || memberCard.CardNumber.Contains("%") || memberCard.CardNumber.Contains("^")
                || memberCard.CardNumber.Contains("Select * "))
                return "Please do not enter special character or sql query";

            if (memberCard.IssueDate >= memberCard.EffectDate)
                return "The issue date needs to be less than the effective date";

            if (memberCard.ValidDate <= memberCard.EffectDate)
                return "The effect date needs to be greater than the valid date";

            return "ok";
        }

        public string ValidateMemberCardWhenUpdate(MemberCard memberCard)
        { 
            var cardExist = _context.MemberCards.FirstOrDefault(x => x.Id == memberCard.Id);
            if (cardExist == null)
                return "Customer does not exist";

            if (string.IsNullOrEmpty(memberCard.CardNumber))
                return "Please enter CardNumber";

            if (string.IsNullOrEmpty(memberCard.Reason))
                return "Please enter Reason";

            if (memberCard.CardNumber.Count() > 10)
                return "The card number must have less than 10 characters";

            if (memberCard.Reason.Count() > 20)
                return "The reason must have less than 20 charaters";

            Regex regex = new Regex(@"^\d{1,10}$");
            if (!regex.IsMatch(memberCard.CardNumber))
                return "CardNumber must be a number and not more than 10 characters";

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

            if (memberCard.IssueDate >= memberCard.EffectDate)
                return "The issue date needs to be less than the effective date";

            if (memberCard.ValidDate <= memberCard.EffectDate)
                return "The effect date needs to be greater than the valid date";

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
        public string ValidateGetMemberList(List<MemberCard> memberCard)
        {
            if(memberCard.Count == 0)
            {
                return "The customer list is empty";
            }
            return "ok";
        }
        public string ValidateDeleteMember(int id)
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
        public string ValidateSearchCardToAddPoint(string cardNumber)
        {
            if (cardNumber.Count() > 10)
                return "The card number must have less than 10 characters";

            Regex regex = new Regex(@"^\d{1,10}$");
            if (!regex.IsMatch(cardNumber))
                return "CardNumber must be a number and not more than 10 characters";

            var res2 = _context.MemberCards
                        .Include(x => x.Customer)
                        .FirstOrDefaultAsync(x => x.CardNumber == cardNumber);
            if (res2.Result == null)
                return "The CardNumber does not exist";

            if (res2.Result.IsActive == false)
                return "The CardNumber has been inactive";

            if (DateTime.Now > res2.Result.ValidDate)
                return "The card has expired";
        
            if (res2.Result.Customer == null)
                return "Empty card!!! No customers yet";
            
            if (res2.Result.Customer.IsActive == false)
                return "The Owner of the card has been inactive";

            return "ok";
        }
    }
}
