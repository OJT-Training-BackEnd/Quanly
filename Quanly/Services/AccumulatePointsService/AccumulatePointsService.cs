using Microsoft.EntityFrameworkCore;
using Quanly.Data;
using Quanly.Models.AccumulatePoints;
using Quanly.Models.Customers;
using Quanly.Models.MemberCards;
using Quanly.Services.ValidPointsService;
using Quanly.ValidationHandling.AccumulatePointsValidation;

namespace Quanly.Services.AccumulatePointsService
{
    public class AccumulatePointsService : IAccumulatePointsService
    {
        private readonly ValidGetAllAccumulatePoints _validGetAllAccumulatePoints;
        private readonly DataContext _dataContext;
        private readonly DeleteAccumulatePoints _deleteAccumulatePoint;
        private readonly SearchAccumulatePoints _searchAccumulatePoints;
        public AccumulatePointsService(ValidGetAllAccumulatePoints validGetAllAccumulatePoints,
            DataContext dataContext,
            DeleteAccumulatePoints deleteAccumulatePoint,
            SearchAccumulatePoints searchAccumulatePoints)
        {
            _validGetAllAccumulatePoints = validGetAllAccumulatePoints;
            _dataContext = dataContext;
            _deleteAccumulatePoint = deleteAccumulatePoint;
            _searchAccumulatePoints = searchAccumulatePoints;
        }

        public async Task<ServiceResponse<List<AccumulatePoint>>> GetAllAccumulatePoints()
        {
            var validPoint = await _dataContext.AccumulatePoints.OrderByDescending(n => n.Id).ToListAsync();

            var validPointsResult = _validGetAllAccumulatePoints.AccumulatePoints(validPoint);

            if (validPointsResult != "ok")
            {
                return new ServiceResponse<List<AccumulatePoint>>
                {
                    Message = validPointsResult,
                    Success = false
                };

            }
            return new ServiceResponse<List<AccumulatePoint>>
            {
                Data = validPoint,
                Message = "Succesfully",
                Success = true
            };
        }

        public async Task<ServiceResponse<List<AccumulatePoint>>> DeleteAccumulatePoints(int pointId)
        {
            var validPoint = _deleteAccumulatePoint.DeletePoints(pointId);
            if (validPoint != "ok")
            {
                return new ServiceResponse<List<AccumulatePoint>>
                {
                    Message = validPoint,
                    Success = false
                };
            }

            var idPoint = await _dataContext.AccumulatePoints.FirstOrDefaultAsync(c => c.Id == pointId);
            _dataContext.AccumulatePoints.Remove(idPoint);
            await _dataContext.SaveChangesAsync();
            return new ServiceResponse<List<AccumulatePoint>>
            {

                Message = "Delete succesfully",
                Success = true
            };
        }

        public async Task<ServiceResponse<AccumulatePoint>> UpdateAccumulatePoints(AccumulatePoint accumulatePoint)
        {
            var validate = _validGetAllAccumulatePoints.checkValidateUpdateAccummulatePoint(accumulatePoint);
            if (validate != "ok")
            {
                return new ServiceResponse<AccumulatePoint>
                {
                    Success = false,
                    Message = validate
                };
            }
            var _accumulatePoint = await _dataContext.AccumulatePoints.Include(x => x.MemberCards).FirstOrDefaultAsync(x => x.Id == accumulatePoint.Id);
            if (_accumulatePoint != null)
            {
                var _membercard = await _dataContext.MemberCards.Include(x => x.Customer)
                    .FirstOrDefaultAsync(x => x.CardNumber == _accumulatePoint.MemberCards.CardNumber);
                if (_membercard != null)
                {

                    _accumulatePoint.Date = accumulatePoint.Date;
                    _accumulatePoint.Reason = accumulatePoint.Reason;
                    _accumulatePoint.Type = accumulatePoint.Type;
                    _accumulatePoint.Money = accumulatePoint.Money;
                    _accumulatePoint.Shop = accumulatePoint.Shop;
                    _accumulatePoint.Note = accumulatePoint.Note;
                    //Update Points
                    var customOldPoint = Convert.ToDouble(_membercard.Customer.Points);// Diem khach hang hien tai
                    
                    var oldPoint = Convert.ToDouble(_accumulatePoint.Points);
                    if (_membercard.Customer.Points == null)
                        _membercard.Customer.Points = "0";
                    if (_membercard.Customer.Points != null)
                    {
                        if (_accumulatePoint.Type.Equals("TRU"))
                        {
                            var newPoint = Convert.ToDouble(accumulatePoint.Points);

                            if (newPoint < oldPoint)
                            {
                                var customerNewPoint = (oldPoint - newPoint) + customOldPoint;

                                _membercard.Customer.Points = customerNewPoint.ToString();
                                _accumulatePoint.Points = newPoint.ToString();
                                await _dataContext.SaveChangesAsync();
                            }
                            else if (newPoint > oldPoint)
                            {
                                if (customOldPoint >= newPoint - oldPoint)
                                {
                                    var customerNewPoint = customOldPoint - (newPoint - oldPoint);
                                    _membercard.Customer.Points = customerNewPoint.ToString();
                                    _accumulatePoint.Points = newPoint.ToString();
                                    await _dataContext.SaveChangesAsync();
                                }
                                else
                                {
                                    return new ServiceResponse<AccumulatePoint>
                                    {
                                        Success = false,
                                        Message = "You do not have any point to minus"
                                    };
                                }
                            }
                        }
                        else if (accumulatePoint.Type.Equals("CONG"))
                        {
                            var money = Convert.ToDouble(accumulatePoint.Money);
                            var newPoint = money / 100;

                            if(oldPoint < newPoint)
                            {
                                var customerNewPoint = customOldPoint + (newPoint - oldPoint);
                                _membercard.Customer.Points = customerNewPoint.ToString();
                                _accumulatePoint.Points = newPoint.ToString();
                                _accumulatePoint.Money = money.ToString();
                                await _dataContext.SaveChangesAsync();
                            }
                            else if(newPoint < oldPoint)
                            {
                                if(customOldPoint >= (oldPoint - newPoint))
                                {
                                    var customerNewPoint  = customOldPoint - (oldPoint - newPoint);
                                    _membercard.Customer.Points = customerNewPoint.ToString();
                                    _accumulatePoint.Points = newPoint.ToString();
                                    _accumulatePoint.Money = money.ToString();
                                    await _dataContext.SaveChangesAsync();
                                }
                                else
                                {
                                    return new ServiceResponse<AccumulatePoint>
                                    {
                                        Success = false,
                                        Message = "You do not have any point to minus"
                                    };
                                }
                            }

                        }
                    }
                    

                    return new ServiceResponse<AccumulatePoint>
                    {
                        Data = _accumulatePoint,
                        Message = " updated succesfully",
                        Success = true

                    };

                }

            }

            return new ServiceResponse<AccumulatePoint>
            {

                Message = " Failed",
                Success = false
            };
        }
        public async Task<ServiceResponse<AccumulatePoint>> search(string cardNumber)
        {
            if (!String.IsNullOrEmpty(cardNumber))
            {
                var _accumulatePoints = await _dataContext.AccumulatePoints.FirstOrDefaultAsync(c => c.MemberCards.CardNumber == cardNumber);
                if (_accumulatePoints == null)
                {
                    return new ServiceResponse<AccumulatePoint>
                    {
                        Success = false,
                        Message = "Test False"

                    };
                }
                return new ServiceResponse<AccumulatePoint>
                {
                    Data = _accumulatePoints,
                    Success = true,
                    Message = "Test"

                };

            }
            return new ServiceResponse<AccumulatePoint>
            {
                Success = false,
                Message = "Test"

            };

        }
        public async Task<ServiceResponse<List<AccumulatePoint>>> searchAccumulatePoints(string key)
        {
            var validPoint = _searchAccumulatePoints.ValidateSearchAccumulatePoint(key);
            if (validPoint != "ok")
            {
                return new ServiceResponse<List<AccumulatePoint>>
                {
                    Message = validPoint,
                    Success = false
                };
            }
            var aPoint = _dataContext.AccumulatePoints.Where(x => x.Reason.ToLower().Contains(key.ToLower())
                                                                   || x.Type.ToLower().Contains(key.ToLower())
                                                                   || x.Money.ToLower().Contains(key.ToLower())
                                                                   || x.Points.ToLower().Contains(key.ToLower())
                                                                   || x.Shop.ToLower().Contains(key.ToLower())
                                                                   || x.Date.ToString().Contains(key));
            if (aPoint.Count() == 0)
            {
                return new ServiceResponse<List<AccumulatePoint>>
                {
                    Message = "Cant not find any result",
                    Success = false
                };
            }

            return new ServiceResponse<List<AccumulatePoint>>
            {
                Data = await aPoint.OrderByDescending(x => x.Id).ToListAsync(),
                Message = "Searching successfully"
            };
        }

        public async Task<ServiceResponse<AccumulatePoint>> CreateAccumulatePoint(AccumulatePoint accumulatePoint)
        {
            var validate = _validGetAllAccumulatePoints.ValidateCreateAccumulatePoint(accumulatePoint);
            if (validate != "Ok")
            {
                return new ServiceResponse<AccumulatePoint>
                {
                    Success = false,
                    Message = validate
                };
            }
            var memberCard = await _dataContext.MemberCards
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.CardNumber == accumulatePoint.MemberCards.CardNumber);
            

            var customer = await _dataContext.Customers.FirstOrDefaultAsync(x => x.Id == memberCard.Customer.Id);
            var oldPoint = Convert.ToDouble(customer.Points);
            if (customer.Points == null)
                customer.Points = "0";
            if (accumulatePoint.Money != null)
            {
                oldPoint += Convert.ToDouble(accumulatePoint.Points);
            }
            else
            {
                if (oldPoint < Convert.ToDouble(accumulatePoint.Points))
                {
                    return new ServiceResponse<AccumulatePoint>
                    {
                        Success = false,
                        Message = "You do not have any point to minus"
                    };
                }
                else
                {
                    oldPoint -= Convert.ToDouble(accumulatePoint.Points);
                }
            }
            var customer2 = await _dataContext.Customers.FirstOrDefaultAsync(x => x.Id == memberCard.Customer.Id);
            customer2.Points = oldPoint.ToString();
            await _dataContext.SaveChangesAsync();
            accumulatePoint.MemberCards = memberCard;
            _dataContext.AccumulatePoints.Add(accumulatePoint);
            await _dataContext.SaveChangesAsync();
            return new ServiceResponse<AccumulatePoint>
            {
                Success = true,
                Message = "Added Successfully"
            };
        }

        public async Task<ServiceResponse<AccumulatePoint>> GetAccumulatePointById(int accumulatePointId)
        {
            var resultAfterValidate = _validGetAllAccumulatePoints.ValidateAccumulatePointId(accumulatePointId);
            if (!resultAfterValidate.Equals("ok"))
            {
                return new ServiceResponse<AccumulatePoint>
                {
                    Success = false,
                    Message = resultAfterValidate
                };
            }
            var _accumulatePoint = await _dataContext.AccumulatePoints.Include(x => x.MemberCards).FirstOrDefaultAsync(x => x.Id == accumulatePointId);
            var _membercard = await _dataContext.MemberCards.Include(x => x.Customer)
                    .FirstOrDefaultAsync(x => x.CardNumber == _accumulatePoint.MemberCards.CardNumber);
          /*  var accumulatePoint = await _dataContext.AccumulatePoints.FindAsync(accumulatePointId);*/
            return new ServiceResponse<AccumulatePoint>
            {
                Success = true,
                Message = "Get transaction successfully",
                Data = _accumulatePoint
            };
        }
    }
}