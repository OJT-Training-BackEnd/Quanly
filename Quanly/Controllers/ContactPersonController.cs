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
        [HttpDelete("DeleteContactPerson")]
        public async Task<ActionResult<ServiceResponse<ContactPerson>>> DeleteContactPerson(int Id)
        {
            return Ok(await _contactPersonService.DeleteContactPerson(Id));
        }
    }
}
