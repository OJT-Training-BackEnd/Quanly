using Quanly.Models.ContactPersons;

namespace Quanly.Services.ContactPersonService
{
    public interface IContactPersonService
    {
        Task<ServiceResponse<List<ContactPerson>>> DeleteContactPerson(int Id);
        Task<ServiceResponse<ContactPerson>> AddNewContactPerson(ContactPerson contactPerson);
    }
}
