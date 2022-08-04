using Microsoft.EntityFrameworkCore;
using Quanly.Data;
using Quanly.Models.Customers;
using Quanly.ValidationHandling.CustomerValidation;
using System.Security.Claims;

namespace Quanly.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _dataContext;
        private readonly ValidGetAllCus _validation;
        private readonly ValidDeleteCus _validDeleteCus;

        public CustomerService(DataContext dataContext, ValidGetAllCus validation, ValidDeleteCus validDeleteCus)
        {
            _dataContext = dataContext;
            _validation = validation;
            _validDeleteCus = validDeleteCus;
        }
        public async Task<ServiceResponse<List<Customer>>> DeleteCustomers(int customerId)
        {

            var validateMessage = _validDeleteCus.ValidDeleteCustomers(customerId);
            if(validateMessage != "ok")
            {
                return new ServiceResponse<List<Customer>>
                {
                    Message = validateMessage,
                    Success = false
                };
            }

            var customer = await _dataContext.Customers.FirstOrDefaultAsync(c => c.Id == customerId); 
            _dataContext.Customers.Remove(customer);
            await _dataContext.SaveChangesAsync();
            return new ServiceResponse<List<Customer>>
            {
                
                Message = "Delete succesfully",
                Success = true
            };

        }

        public async Task<ServiceResponse<List<Customer>>> GetAllCustomers()
        {   

            var customers = await _dataContext.Customers.OrderByDescending(n => n.Id).ToListAsync();

            var validateResult = _validation.validCustomers(customers);
            if (validateResult != "ok")
            {
                return new ServiceResponse<List<Customer>>
                {
                    Message = validateResult,
                    Success = false
                };
            }

            return new ServiceResponse<List<Customer>>
            {   
                Data = customers,
                Message = "Succesfully",
                Success = true
            };
        }
        
    }
}
