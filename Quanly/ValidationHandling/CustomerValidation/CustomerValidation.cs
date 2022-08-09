using Quanly.Data;
using Quanly.Models.Customers;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Quanly.ValidationHandling.CustomerValidation
{
    public class CustomerValidation
    {
        private readonly DataContext _dataContext;

        public CustomerValidation(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public string ValidateCustomerId(int? customerId)
        {
            try
            {
                if(customerId == null)
                    return "Please enter customer id";
  
                var customer = _dataContext.Customers.Find(customerId);
                if (customer == null)
                    return "This customer is not exist";

            }
            catch (System.Exception ex)
            {

                return ex.Message.ToString();
            }

            return "ok";
        }


        public string ValidateNewCustomer(Customer customer)
        {
            var customerExist = _dataContext.Customers.FirstOrDefault(x => x.Id == customer.Id);
            if (customerExist != null)
            {
                return "Customer has aldready existed";
            }
            if (String.IsNullOrWhiteSpace(customer.CustomerName))
            {
                return "Customer name can not be null or empty";
            }

            if (IsValidEmail(customer.Email) == false)
            {
                return "Customer Email khong dung format";
            }
            if (customer.CustomerName.Contains("!") || customer.CustomerName.Contains("@")
              || customer.CustomerName.Contains("#") || customer.CustomerName.Contains("$")
              || customer.CustomerName.Contains("%") || customer.CustomerName.Contains("^")
              || customer.CustomerName.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }
            if (customer.Address.Contains('!') || customer.Address.Contains("@")
              || customer.Address.Contains("#") || customer.Address.Contains("$")
              || customer.Address.Contains("%") || customer.Address.Contains("^")
              || customer.Address.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }
            if (customer.CompanyName.Contains('!') || customer.CompanyName.Contains("@")
              || customer.CompanyName.Contains("#") || customer.CompanyName.Contains("$")
              || customer.CompanyName.Contains("%") || customer.CompanyName.Contains("^")
              || customer.CompanyName.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }

            if (customer.Phone.Contains('!') || customer.Phone.Contains("@")
              || customer.Phone.Contains("#") || customer.Phone.Contains("$")
              || customer.Phone.Contains("%") || customer.Phone.Contains("^")
              || customer.Phone.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }
            if (IsIdentityCard(customer.Phone) || IsIdentityCard(customer.CompanyPhone) || IsIdentityCard(customer.TelePhone))
            {
                return "Please input correct format Phone";
            }
            if (customer.Age.Contains('!') || customer.Age.Contains("@")
            || customer.Age.Contains("#") || customer.Age.Contains("$")
            || customer.Age.Contains("%") || customer.Age.Contains("^")
            || customer.Age.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }

            if (customer.Email.Contains('!') || customer.Email.Contains("@")
            || customer.Email.Contains("#") || customer.Email.Contains("$")
            || customer.Email.Contains("%") || customer.Email.Contains("^")
            || customer.Email.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }

            return "ok";
        }

        //Check Update Customer
        public string ValidateUpdateCustomer(Customer customer)
        {

            //check CustomerName
            if (customer.CustomerName.Contains("!") || customer.CustomerName.Contains("@")
               || customer.CustomerName.Contains("#") || customer.CustomerName.Contains("$")
               || customer.CustomerName.Contains("%") || customer.CustomerName.Contains("^")
               || customer.CustomerName.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }
            if (customer.Address.Contains('!') || customer.Address.Contains("@")
            || customer.Address.Contains("#") || customer.Address.Contains("$")
            || customer.Address.Contains("%") || customer.Address.Contains("^")
            || customer.Address.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }
            if (customer.CompanyName.Contains('!') || customer.CompanyName.Contains("@")
              || customer.CompanyName.Contains("#") || customer.CompanyName.Contains("$")
              || customer.CompanyName.Contains("%") || customer.CompanyName.Contains("^")
              || customer.CompanyName.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }

            if (customer.Phone.Contains('!') || customer.Phone.Contains("@")
              || customer.Phone.Contains("#") || customer.Phone.Contains("$")
              || customer.Phone.Contains("%") || customer.Phone.Contains("^")
              || customer.Phone.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }
            if (IsIdentityCard(customer.Phone) || IsIdentityCard(customer.CompanyPhone) || IsIdentityCard(customer.TelePhone))
            {
                return "Please input correct format Phone";
            }
            if (customer.Age.Contains('!') || customer.Age.Contains("@")
            || customer.Age.Contains("#") || customer.Age.Contains("$")
            || customer.Age.Contains("%") || customer.Age.Contains("^")
            || customer.Age.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }

            if (customer.Email.Contains('!') || customer.Email.Contains("@")
            || customer.Email.Contains("#") || customer.Email.Contains("$")
            || customer.Email.Contains("%") || customer.Email.Contains("^")
            || customer.Email.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }

            if (String.IsNullOrWhiteSpace(customer.CustomerName) || String.IsNullOrEmpty(customer.CustomerName))
            {
                return "Customer name can not be null or empty";
            }

            if (IsValidEmail(customer.Email) == false)
            {
                return "Customer Email khong dung format";
            }

            return "ok";
        }

        //Check Valid Email
        public bool IsValidEmail(string email)
        {

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        public bool IsIdentityCard(string number)
        {
            if (number != null) return Regex.IsMatch(number, @"^[0-9]{10}$");
            else return false;
        }

        //Check Search Customer
        public string searchCustomerValidate(string keyword)
        {
            if (keyword.Contains("!") || keyword.Contains("@")
              || keyword.Contains("#") || keyword.Contains("$")
              || keyword.Contains("%") || keyword.Contains("^")
              || keyword.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }
            if (keyword.Count() > 50)
            {
                return "Key word not more than 50 characters";
            }
            return "ok";
        }

        public string sortCustomerValidate(string sortFieldCustomer)
        {
            if (String.IsNullOrEmpty(sortFieldCustomer))
            {
                return "Khong duoc null";
            }
            if (sortFieldCustomer.Count() <= 0)
            {
                return "Chu co List";
            }
            return "ok";
        }

        public string cardIssueValidate(string capTheValidate, int id)
        {
            if (capTheValidate.Contains("!") || capTheValidate.Contains("@")
               || capTheValidate.Contains("#") || capTheValidate.Contains("$")
               || capTheValidate.Contains("%") || capTheValidate.Contains("^")
               || capTheValidate.Contains("Select * "))
            {
                return "Please do not enter special character or sql query";
            }
            if (id == null || id == 0)
            {
                return "You must input correct format Id";
            }

            if (String.IsNullOrEmpty(capTheValidate))
            {
                return "Card number not found or not available! You must be input number";
            }
            var customer = _dataContext.Customers.FirstOrDefault(p => p.Id == id);
            if (customer == null)
            {
                return "Card number not found or not available! You must be input number";
            }
            var _cartNumber = _dataContext.MemberCards.FirstOrDefault(p => p.CardNumber == capTheValidate);
            if (_cartNumber == null)
            {
                return "Card number not found or not available! You must be input number";
            }
            var _checkCustomerMemberCard = _dataContext.MemberCards.FirstOrDefault(p => p.CardNumber == capTheValidate && p.Customer == null);
            if (_checkCustomerMemberCard == null)
            {
                return "Card number used by the customer";
            }
            var _checkIsActive = _dataContext.MemberCards.FirstOrDefault(p => p.CardNumber == capTheValidate && p.IsActive == false);
            if (_checkIsActive != null)
            {
                return "Card number has been banned";
            }
            return "ok";
        }

        public string ValidateCustomer(int id)
        {
            var cusexist = _dataContext.Customers.FirstOrDefault(x => x.Id == id);
            if (cusexist == null)
            {
                return "Customer is not exist";
            }
            return "ok";
        }
        
        public string ValidateViewCustomerTransactionHistory(int customerId)

        {
            if (customerId == null)
                return "Please enter customerId";
            /*var transactionOfCus = _dataContext.MemberCards
                .Include(x => x.Customer).Include(x => x.AccumulatePoints)
                .FirstOrDefault(x => x.Id == customerId);
            if (transactionOfCus.AccumulatePoints == null)
                return "Does not has any transaction";*/

            return "ok";
        }

    }
}
