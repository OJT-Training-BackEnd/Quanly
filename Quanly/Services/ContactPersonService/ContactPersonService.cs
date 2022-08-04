using Microsoft.EntityFrameworkCore;
using Quanly.Data;
using Quanly.Models.ContactPersons;
using Quanly.ValidationHandling.ContactPersonValidation;

namespace Quanly.Services.ContactPersonService
{
    public class ContactPersonService : IContactPersonService
    {
        private readonly DataContext _dataContext;
        private readonly ContactPersonValidation _contactpersonValidation;
        public ContactPersonService(DataContext dataContext, ContactPersonValidation contactpersonValidation)
        {
            _dataContext = dataContext;
            _contactpersonValidation = contactpersonValidation;
        }

        public async Task<ServiceResponse<List<ContactPerson>>> DeleteContactPerson(int Id)
        {
            var validate = _contactpersonValidation.ValidateDeleteContactPerson(Id);
            if(validate != "ok")
            {
                return new ServiceResponse<List<ContactPerson>>
                {
                    Message = validate,
                    Success = false
                };
            }
            var contact = await _dataContext.ContactPersons.FirstOrDefaultAsync(x => x.Id == Id);
            _dataContext.ContactPersons.Remove(contact);
            await _dataContext.SaveChangesAsync();
            return new ServiceResponse<List<ContactPerson>>
            {
                Message = "Delete Successfully",
                Success = true
            };
        }
    }
}
