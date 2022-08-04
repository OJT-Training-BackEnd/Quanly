using Quanly.Models.Customers;

namespace Quanly.Services.Customers
{
    public interface ICustomerService
    {
        Task<ServiceResponse<Customer>> AddCustomer(Customer customer);
        Task<ServiceResponse<Customer>> EditCustomer(Customer customer);

        Task<ServiceResponse<List<Customer>>> searchCustomer(String name);

        Task<ServiceResponse<List<Customer>>> sortFieldCustomer(string sortBy);


    }
}
