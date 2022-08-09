using Microsoft.EntityFrameworkCore;
using Quanly.Data;
using Quanly.Models.AccumulatePoints;
using Quanly.Models.Customers;
using Quanly.Models.MemberCards;
using Quanly.ValidationHandling.CustomerValidation;
using System.Security.Claims;

namespace Quanly.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _dataContext;
        private readonly ValidGetAllCus _validation;
        private readonly ValidDeleteCus _validDeleteCus;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CustomerValidation _customerValidation;
        public CustomerService(DataContext dataContext,
            ValidGetAllCus validation,
            ValidDeleteCus validDeleteCus,
            IHttpContextAccessor httpContextAccessor,
            CustomerValidation customerValidation)
        {
            _customerValidation = customerValidation;
            _httpContextAccessor = httpContextAccessor;
            _dataContext = dataContext;
            _validation = validation;
            _validDeleteCus = validDeleteCus;
        }


        public async Task<ServiceResponse<List<Customer>>> DeleteCustomers(int customerId)
        {

            var validateMessage = _validDeleteCus.ValidDeleteCustomers(customerId);
            if (validateMessage != "ok")
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

        public async Task<ServiceResponse<Customer>> AddCustomer(Customer customer)
        {

            var customerValidate = _customerValidation.ValidateNewCustomer(customer);
            if (customerValidate != "ok")
            {
                return new ServiceResponse<Customer>
                {
                    Success = false,
                    Message = customerValidate
                };
            }
            var _customer = new Customer
            {
                Code = customer.Code?.Trim(),
                CustomerName = customer.CustomerName,
                District = customer.District,
                Type = customer.Type,
                Phone = customer.Phone?.Trim(),
                TelePhone = customer.TelePhone?.Trim(),
                Email = customer.Email?.Trim(),
                Fax = customer.Fax?.Trim(),
                Gender = customer.Gender,
                IsMarried = customer.IsMarried,
                BirthDate = customer.BirthDate,
                IdentityCard = customer.IdentityCard?.Trim(),
                DateOfRecord = customer.DateOfRecord,
                CompanyName = customer.CompanyName,
                CompanyPhone = customer.CompanyPhone?.Trim(),
                Contact = customer.Contact,
                Position = customer.Position,
                MemberCards = null,
                ContactPersons = null
            };
            await _dataContext.Customers.AddAsync(_customer);
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

            _dataContext.Customers.Update(customer);
            await _dataContext.SaveChangesAsync();

            return new ServiceResponse<Customer>
            {
                Success = true,
                Message = "Updated Successfully"

            };

        }

        public async Task<ServiceResponse<List<Customer>>> SearchCustomer(string searchString)
        {
            var searchValidation = _customerValidation.searchCustomerValidate(searchString);
            if (searchValidation != "ok")
            {
                return new ServiceResponse<List<Customer>>
                {
                    Success = false,
                    Message = searchValidation
                };
            }

            var allCustomer = _dataContext.Customers.OrderBy(c => c.CustomerName).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                allCustomer = SearchCustomerByFeild(searchString, allCustomer);

            if (allCustomer.Count() == 0)
            {
                return new ServiceResponse<List<Customer>>
                {
                    Success = false,
                    Message = "Khong co"
                };
            }
            
            return new ServiceResponse<List<Customer>>
            {
                Data =  await allCustomer.OrderByDescending(x => x.Id).ToListAsync(),
                Success = true,
                Message = "Search Successfully"
            };
        }

        private static List<Customer> SearchCustomerByFeild(string searchString, List<Customer> allCustomer)
        {
            allCustomer = allCustomer.Where(n => n.CustomerName.ToLower().Trim().Contains(searchString.ToLower().Trim()) || n.Code.ToLower().Trim().Contains(searchString.ToLower().Trim()) ||
                                                        n.Phone.ToLower().Trim().Contains(searchString.ToLower().Trim()) || n.Type.ToLower().Trim().Contains(searchString.ToLower().Trim()) ||
                                                        n.Importer.ToLower().Trim().Contains(searchString.ToLower().Trim()) || n.District.ToLower().Trim().Contains(searchString.ToLower().Trim()) ||
                                                        n.Type.ToLower().Trim().Contains(searchString.ToLower().Trim())).ToList();
            return allCustomer;
        }

        public async Task<ServiceResponse<List<Customer>>> SortFieldCustomer(string sortBy)
        {
            var sortCustomer = _dataContext.Customers.OrderBy(c => c.CustomerName).ToList();

            if (!String.IsNullOrEmpty(sortBy))
            {
                sortCustomer = SortCustomerByField(sortBy, sortCustomer);
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

        private static List<Customer> SortCustomerByField(string sortBy, List<Customer> sortCustomer)
        {
            switch (sortBy.Trim())
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

            return sortCustomer;
        }

        public async Task<ServiceResponse<string>> ChangeStatusCustomer(int id)
        {
            try
            {
                var validate = _customerValidation.ValidateCustomer(id);
                if (validate != "ok")
                {
                    return new ServiceResponse<string>
                    {
                        Message = validate,
                        Success = false
                    };
                }
                var customerExist = _dataContext.Customers.FirstOrDefault(x => x.Id == id);
                if (customerExist.IsActive == true)
                {
                    customerExist.IsActive = false;
                }
                else
                {
                    customerExist.IsActive = true;
                }
                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<string>
                {
                    Success = true,
                    Message = "Changed Successfully"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = ex.Message
                };
            }

        }

        public async Task<ServiceResponse<Customer>> CardIssue(string cardNumber, int id)
        {
            var cardIssueCValidate = _customerValidation.cardIssueValidate(cardNumber, id);
            if (cardIssueCValidate != "ok")
            {
                return new ServiceResponse<Customer>
                {
                    Success = false,
                    Message = cardIssueCValidate
                };
            }
            var customer = await _dataContext.Customers.FirstOrDefaultAsync(p => p.Id == id);
            var _memberCard = await _dataContext.MemberCards.FirstOrDefaultAsync(p => p.CardNumber == cardNumber && p.Customer == null);
            if (_memberCard != null)
            {
                _memberCard.Customer = customer;
                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<Customer>
                {
                    Data = customer,
                    Success = true,
                    Message = "Success card issue"
                };
            }
            return new ServiceResponse<Customer>
            {
                Success = false,
                Message = "Failed card issue"
            };
        }

        public async Task<ServiceResponse<List<AccumulatePoint>>> ViewCustomerTransactionHistory(int customerId)
        {
            var validate = _customerValidation.ValidateViewCustomerTransactionHistory(customerId);
            if (validate != "ok")
            {
                return new ServiceResponse<List<AccumulatePoint>>
                {
                    Success = false,
                    Message = validate
                };
            }
            var cardList = await _dataContext.MemberCards.Include(x => x.Customer)
                .Where(x => x.Customer.Id == customerId).ToListAsync();
            List<AccumulatePoint> transaction = await OrderByDescendingAccumulatePonint(cardList);

            return new ServiceResponse<List<AccumulatePoint>>
            {
                Data = transaction,
                Success = true,
                Message = "View Customer Transaction History Successfully"
            };
        }

        private async Task<List<AccumulatePoint>> OrderByDescendingAccumulatePonint(List<MemberCard> cardList)
        {
            var transaction = new List<AccumulatePoint>();
            foreach (var card in cardList)
            {
                transaction = await _dataContext.AccumulatePoints
                    .Where(x => x.MemberCards.Id == card.Id).OrderByDescending(x => x.Id).ToListAsync();
            }

            return transaction;
        }

        public async Task<ServiceResponse<Customer>> GetCustomerById(int customerId)
        {
            var resultAfterValidate = _customerValidation.ValidateCustomerId(customerId);
            if (!resultAfterValidate.Equals("ok"))
            {
                return new ServiceResponse<Customer>
                {
                    Success = false,
                    Message = resultAfterValidate
                };
            }

            var customer = await _dataContext.Customers.FindAsync(customerId);

            return new ServiceResponse<Customer>
            {
                Data = customer,
                Success = true,
                Message = "Get customer info successfully"
            };
                
        }
    }
}
