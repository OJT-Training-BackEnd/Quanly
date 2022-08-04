using Quanly.Data;
using Quanly.Models.Customers;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Quanly.ValidationHandling.CustomerValidation
{
    public class CustomerValidation
    {
        private readonly DataContext _dataContext;

        public CustomerValidation(DataContext  dataContext)
        {
            _dataContext = dataContext; 
        }

        public string ValidateCustomer(Customer customer)
        {
            var customerExist = _dataContext.Customers.FirstOrDefault(x => x.Id == customer.Id);
            if (customerExist != null)
            {
                return "Customer has aldready existed";
            }
            if (String.IsNullOrWhiteSpace(customer.CustomerName) )
            {
                return "Customer name can not be null or empty";
            }

            if (IsValidEmail(customer.Email) == false)
            {
                return "Customer Email khong dung format";
            }

            if (String.IsNullOrWhiteSpace(customer.CompanyPhone) || String.IsNullOrWhiteSpace(customer.Phone) || String.IsNullOrWhiteSpace(customer.TelePhone))
            {
                return "Customer Phone khong dung format";
            }
            
            return "ok";
        }

        public string ValidateUpdateCustomer(Customer customer)
        {
          
            if (String.IsNullOrWhiteSpace(customer.CustomerName))
            {
                return "Customer name can not be null or empty";
            }

            if (IsValidEmail(customer.Email) == false)
            {
                return "Customer Email khong dung format";
            }

            if (String.IsNullOrWhiteSpace(customer.CompanyPhone) || String.IsNullOrWhiteSpace(customer.Phone) || String.IsNullOrWhiteSpace(customer.TelePhone))
            {
                return "Customer Phone khong dung format";
            }

            return "ok";
        }
        public  bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

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
       
       





    }
}
