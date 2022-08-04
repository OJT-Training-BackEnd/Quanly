﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quanly.Models.Customers;
using Quanly.Services.Customers;

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

        [HttpGet("SearchName/{name}")]
        public async Task<ActionResult<ServiceResponse<List<Customer>>>> SearchCustomerName(string name)
        {
            return Ok(await _customerService.searchCustomer(name));
        }

        [HttpGet("Sort-Customer")]
        public async Task<ActionResult<ServiceResponse<List<Customer>>>> SortCustomerName(string sortBy)
        {
            return Ok(await _customerService.sortFieldCustomer(sortBy));
        }

    }
}