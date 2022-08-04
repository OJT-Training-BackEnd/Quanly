using Quanly.Models.Customers;

namespace Quanly.ValidationHandling.CustomerValidation
{
    public class ValidGetAllCus
    {
        public string validCustomers(List<Customer> customers)
        {
            if(customers == null)
                return "The customer list is empty";



            return "ok";
        }
    }
}
