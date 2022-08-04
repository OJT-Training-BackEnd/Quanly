using Quanly.Data;
using Quanly.Models.Customers;

namespace Quanly.ValidationHandling.CustomerValidation
{
    public class ValidDeleteCus
    {
        private readonly DataContext _context;

        public ValidDeleteCus(DataContext context)
        {
            _context = context;
        }

        public string ValidDeleteCustomers(int customerId)
        {
            
            var customer = _context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return "This customer is not existed";
            }
            
            return "ok";

        }

    }
}
