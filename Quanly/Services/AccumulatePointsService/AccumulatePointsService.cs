﻿using Microsoft.EntityFrameworkCore;
using Quanly.Data;
using Quanly.Models.AccumulatePoints;
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

        public AccumulatePointsService(ValidGetAllAccumulatePoints validGetAllAccumulatePoints,
            DataContext dataContext,
            DeleteAccumulatePoints deleteAccumulatePoint)
        {
            _validGetAllAccumulatePoints = validGetAllAccumulatePoints;
            _dataContext = dataContext;
            _deleteAccumulatePoint = deleteAccumulatePoint;
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

        public async Task<ServiceResponse<AccumulatePoint>> UpdateAccumulatePoints(AccumulatePoint accumulatePoint, string cardNumber)
        {
            var _accumulatePoints = await _dataContext.AccumulatePoints.FirstOrDefaultAsync(c => c.MemberCards.CardNumber == cardNumber);
            if (_accumulatePoints != null)
            {
                _accumulatePoints.Reason = accumulatePoint.Reason;
                _accumulatePoints.MemberCards.CardNumber = accumulatePoint.MemberCards.CardNumber;
                var _memberCard = await _dataContext.MemberCards.FirstOrDefaultAsync(c => c.CardNumber == _accumulatePoints.MemberCards.CardNumber);
                if (_memberCard != null)
                {
                    _memberCard.Type = accumulatePoint.MemberCards.Type;
                    _memberCard.IssueDate = accumulatePoint.MemberCards.IssueDate;
                    _memberCard.Customer.CustomerName = accumulatePoint.MemberCards.Customer.CustomerName;
                    _memberCard.Customer.CompanyName = accumulatePoint.MemberCards.Customer.CompanyName;
                    _memberCard.Customer.Address = accumulatePoint.MemberCards.Customer.Address;
                }
                _accumulatePoints.Type = accumulatePoint.Type;
                _accumulatePoints.Money = accumulatePoint.Money;
                _accumulatePoints.Points = accumulatePoint.Points;
                _accumulatePoints.Shop = accumulatePoint.Shop;


                await _dataContext.SaveChangesAsync();

                return new ServiceResponse<AccumulatePoint>
                {
                    Data = _accumulatePoints,
                    Success = true,
                    Message ="Test"

                };
            }
            return new ServiceResponse<AccumulatePoint>
            {
                Success = false,
                Message = "Test False"

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

    }
}
