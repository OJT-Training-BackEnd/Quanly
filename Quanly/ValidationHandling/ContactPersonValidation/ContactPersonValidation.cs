using Quanly.Data;
using Quanly.Models.ContactPersons;
using System.Text.RegularExpressions;

namespace Quanly.ValidationHandling.ContactPersonValidation
{
    public class ContactPersonValidation
    {
        private readonly DataContext _dataContext;
        public ContactPersonValidation(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public string ValidateDeleteContactPerson(int id)
        {
            var contactperson = _dataContext.ContactPersons.FirstOrDefault(x => x.Id == id);
            if (contactperson == null)
            {
                return "The ContactPerson is not exist";
            }
            return "ok";
        }
        public string ValidateAddNewContactPerson(ContactPerson contactPerson)
        {
            if (string.IsNullOrEmpty(contactPerson.FullName))
                return "Please enter FullName";

            if (contactPerson.FullName.Contains("!") || contactPerson.FullName.Contains("@")
                || contactPerson.FullName.Contains("#") || contactPerson.FullName.Contains("$")
                || contactPerson.FullName.Contains("%") || contactPerson.FullName.Contains("^")
                || contactPerson.FullName.Contains("Select * "))
                return "Please do not enter special character or sql query";

            if (string.IsNullOrEmpty(contactPerson.Phone))
                return "Please enter Phone";

            Regex regex = new Regex(@"^\d{10,11}$");
            if (!regex.IsMatch(contactPerson.Phone))
                return "The Phone number must from 10 to 11 numbers";

            Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regexEmail.IsMatch(contactPerson.Email))
                return "Please enter the email with right format";
            return "ok";
        }
    }
}