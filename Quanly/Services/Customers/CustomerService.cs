using Quanly.Data;
using Quanly.Models.Customers;
using Quanly.ValidationHandling.CustomerValidation;
using Microsoft.EntityFrameworkCore;

namespace Quanly.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _dataContext;
        private readonly CustomerValidation _customerValidation;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerService(IHttpContextAccessor httpContextAccessor, DataContext dataContext, CustomerValidation customerValidation)
        {
            _customerValidation = customerValidation;
            _httpContextAccessor = httpContextAccessor;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<Customer>> AddCustomer(Customer customer)
        {
            var customerValidate = _customerValidation.ValidateCustomer(customer);
            if (customerValidate != "ok")
            {
                return new ServiceResponse<Customer>
                {
                    Success = false,
                    Message = customerValidate
                };
            }
            
            await _dataContext.Customers.AddAsync(customer);
            await _dataContext.SaveChangesAsync();
            return new ServiceResponse<Customer>
            {
                Success = true,
                Message = "Added Successfully"
                
            };
        }

        

        public async Task<ServiceResponse<Customer>> EditCustomer(Customer customer)
        {
            var customerValidate = _customerValidation.ValidateUpdateCustomer(customer);
            if (customerValidate != "ok")
            {
                return new ServiceResponse<Customer>
                {
                    Success = false,
                    Message = customerValidate
                };
            }

           /* var _customer = _dataContext.Customers.FirstOrDefault(x => x.Id == id);*/
           /* if(_customer != null)
            {
                _customer.CustomerName = customer.CustomerName;
                _customer.Code = customer.Code;
                _customer.Address = customer.Address;
                _customer.Importer = customer.Importer;
                _customer.Phone = customer.Phone;
                _customer.Email = customer.Email;
                _customer.IdentityCard = customer.IdentityCard;
                _customer.BirthDate = customer.BirthDate;
                _customer.CompanyName = customer.CompanyName;
                _customer.TelePhone = customer.TelePhone;
                _customer.CompanyPhone = customer.CompanyPhone; 
                _customer.District = customer.District;
                _customer.Contact = customer.Contact;
                _customer.ContactPersons = customer.ContactPersons;
                _customer.Fax = customer.Fax;
                _customer.Gender = customer.Gender;
                _customer.IsMarried = customer.IsMarried;
                _customer.Type= customer.Type;
                _customer.IsActive = customer.IsActive;

                await _dataContext.SaveChangesAsync();

            }*/

            _dataContext.Customers.Update(customer);
            await _dataContext.SaveChangesAsync();

            return new ServiceResponse<Customer>
            {
                Success = true,
                Message = "Updated Successfully"

            };

        }

        public async Task<ServiceResponse<List<Customer>>> searchCustomer(string name)
        {
            IQueryable<Customer> query = _dataContext.Customers;

            if (!String.IsNullOrWhiteSpace(name))
            {
                query = query.Where(e => e.CustomerName.Contains(name));
                return new ServiceResponse<List<Customer>>
                {
                    Data = await query.ToListAsync(),
                    Success = true,
                    Message = "Success Search"
                };
            }
            return new ServiceResponse<List<Customer>>
            {
               
                Success = false,
                Message = "Failed Search"
            };
        }

        public async Task<ServiceResponse<List<Customer>>> sortFieldCustomer(string sortBy)
        {
            var sortCustomer = _dataContext.Customers.OrderBy(c => c.CustomerName).ToList();

            if (!String.IsNullOrEmpty(sortBy))
            {
                switch(sortBy)
                {
                    case "name_desc":
                            sortCustomer = sortCustomer.OrderByDescending(n => n.CompanyName).ToList();
                            break;
                    case "phone_desc":
                        sortCustomer = sortCustomer.OrderByDescending(n => n.Phone).ToList();
                        break;
                    case "address_desc":
                        sortCustomer = sortCustomer.OrderByDescending(n => n.Address).ToList();
                        break;
                    case "type_desc":
                        sortCustomer = sortCustomer.OrderByDescending(n => n.MemberCards.GetType()).ToList();
                        break;
                    default:
                        break;

                }
                return new ServiceResponse<List<Customer>>
                {
                    Data = sortCustomer,
                    Success = false,
                    Message = "Failed Search"
                };
            }
            return new ServiceResponse<List<Customer>>
            {

                Success = false,
                Message = "Failed"
            };
        }

        /*public async Task<ServiceResponse<Customer>> CapThe()
        {
            var customer = _dataContext.Customers.FirstOrDefault();
        }
         */
      
    }
}
