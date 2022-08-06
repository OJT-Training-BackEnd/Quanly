using Quanly.Models.Customers;

namespace Quanly.ValidationHandling.CustomerValidation
{
    public class ValidGetAllCus
    {
        public string validCustomers(List<Customer> customers)
        {
            if(customers.Count == 0)
                return "The customer list is empty";
            return "ok";
        }
    }
}
