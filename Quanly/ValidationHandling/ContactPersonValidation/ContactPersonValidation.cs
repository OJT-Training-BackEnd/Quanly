using Quanly.Data;
using Quanly.Models.ContactPersons;

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
    }
}