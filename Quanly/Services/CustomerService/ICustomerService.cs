using Quanly.Models.Customers;

namespace Quanly.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<ServiceResponse<List<Customer>>> GetAllCustomers();
        Task<ServiceResponse<List<Customer>>> DeleteCustomers(int customerId);
        Task<ServiceResponse<Customer>> AddCustomer(Customer customer);
        Task<ServiceResponse<Customer>> EditCustomer(Customer customer);
        Task<ServiceResponse<List<Customer>>> searchCustomer(string name);
        Task<ServiceResponse<List<Customer>>> sortFieldCustomer(string sortBy);

        Task<ServiceResponse<string>> changeStatusCustomer(int id);
    }
}
