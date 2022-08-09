using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quanly.Models.AccumulatePoints;
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

        [HttpPost("Add-User")]
        public async Task<ActionResult<ServiceResponse<Customer>>> AddCustomer(Customer customer)
        {
            return Ok(await _customerService.AddCustomer(customer));
        }

        [HttpPut("Update-User")]
        public async Task<ActionResult<ServiceResponse<Customer>>> EditCustomer(Customer customer)
        {
            return Ok(await _customerService.EditCustomer(customer));
        }

        [HttpGet("SearchName")]
        public async Task<ActionResult<ServiceResponse<List<Customer>>>> SearchCustomerName(string name)
        {
            return Ok(await _customerService.SearchCustomer(name));
        }

        [HttpGet("Sort-Customer")]
        public async Task<ActionResult<ServiceResponse<List<Customer>>>> SortCustomerName(string sortBy)
        {
            return Ok(await _customerService.SortFieldCustomer(sortBy));
        }


        [HttpPut("Card-Issue")]
        public async Task<ActionResult<ServiceResponse<Customer>>> CardIssue(string cardNumber, int id)
        {
            return Ok(await _customerService.CardIssue(cardNumber, id));
        }

        [HttpPut("Active/Inactive Customer")]
        public async Task<ActionResult<ServiceResponse<string>>> ChangeStatusCustomer(int id)
        {
            return Ok(await _customerService.ChangeStatusCustomer(id));

        }
        [HttpGet("ViewCustomerTransactionHistory")]
        public async Task<ActionResult<ServiceResponse<List<AccumulatePoint>>>> ViewCustomerTransactionHistory(int cusId)
        {
            return Ok(await _customerService.ViewCustomerTransactionHistory(cusId));
        }

        [HttpGet("GetCustomerById/{customerId}")]
        public async Task<ActionResult<ServiceResponse<Customer>>> GetCustomerById(int customerId)
        {
            return Ok(await _customerService.GetCustomerById(customerId));
        }
    }
}
