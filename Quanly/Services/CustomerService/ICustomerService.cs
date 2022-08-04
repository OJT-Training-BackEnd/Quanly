using Quanly.Models.Customers;

namespace Quanly.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<ServiceResponse<List<Customer>>> GetAllCustomers();

        Task<ServiceResponse<List<Customer>>> DeleteCustomers(int customerId);
    }
}
