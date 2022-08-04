using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quanly.Models.Customers;
using Quanly.Services.CustomerService;

namespace Quanly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        
        [HttpGet]
            
        public async Task<ActionResult<ServiceResponse<List<Customer>>>> GetAllCustomer() 
        {
            return Ok(await _customerService.GetAllCustomers());        
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<Customer>>>> DeleteCustomer(int cusId)
        {
            return Ok(await _customerService.DeleteCustomers(cusId));
        }
    }
}
