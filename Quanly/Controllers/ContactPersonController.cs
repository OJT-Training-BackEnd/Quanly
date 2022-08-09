using Microsoft.AspNetCore.Mvc;
using Quanly.Models.ContactPersons;
using Quanly.Services.ContactPersonService;

namespace Quanly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactPersonController : ControllerBase
    {
        private readonly IContactPersonService _contactPersonService;
        public ContactPersonController(IContactPersonService contactService)
        {
            _contactPersonService = contactService;
        }
        [HttpDelete("DeleteContactPerson/{id}")]
        public async Task<ActionResult<ServiceResponse<ContactPerson>>> DeleteContactPerson(int id)
        {
            return Ok(await _contactPersonService.DeleteContactPerson(id));
        }
        [HttpPost("AddNewContactPerson")]
        public async Task<ActionResult<ServiceResponse<ContactPerson>>> AddNewContactPerson(ContactPerson contactPerson)
        {
            return Ok(await _contactPersonService.AddNewContactPerson(contactPerson));
        }
    }
}
