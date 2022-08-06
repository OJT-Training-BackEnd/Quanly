using Quanly.Models.AccumulatePoints;
using Quanly.Models.Customers;

namespace Quanly.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<ServiceResponse<List<Customer>>> GetAllCustomers();
        Task<ServiceResponse<List<Customer>>> DeleteCustomers(int customerId);
        Task<ServiceResponse<Customer>> AddCustomer(Customer customer);
        Task<ServiceResponse<Customer>> EditCustomer(Customer customer);
        Task<ServiceResponse<List<Customer>>> searchCustomer(string searchString);
        Task<ServiceResponse<List<Customer>>> sortFieldCustomer(string sortBy);
        Task<ServiceResponse<Customer>> CardIssue(string cardNumber, int id);
        Task<ServiceResponse<string>> changeStatusCustomer(int id);
        Task<ServiceResponse<List<AccumulatePoint>>> ViewCustomerTransactionHistory(int customerId);
    }
}
