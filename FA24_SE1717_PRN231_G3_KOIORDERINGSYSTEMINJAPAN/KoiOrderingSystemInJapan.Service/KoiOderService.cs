﻿using Azure.Core;
using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Data.Request.KoiOrder;
using KoiOrderingSystemInJapan.Data.Request.Payment;
using KoiOrderingSystemInJapan.Data.Request.ServiceOrder;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service
{
    public interface IKoiOrderService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(Guid id);
        Task<IBusinessResult> Save(KoiOrder koiOrder);
        Task<IBusinessResult> DeleteById(Guid id);
        Task<IBusinessResult> CreatePayment(RequestPaymentKoiOrderModel koiOrder);
    }
    public class KoiOrderService : IKoiOrderService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;
        public KoiOrderService()
        {
            _unitOfWork ??= new UnitOfWork();
            _paymentService ??= new PaymentService();
        }

        public async Task<IBusinessResult> DeleteById(Guid code)
        {
            try
            {
                var koiOrder = await _unitOfWork.KoiOrder.GetByIdAsync(code);
                if (koiOrder == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new KoiOrder());
                }
                else
                {
                    var result = await _unitOfWork.KoiOrder.RemoveAsync(koiOrder);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, koiOrder);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, koiOrder);
                    }
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetAll()
        {
            #region Business rule

            #endregion
            var koiOrder = await _unitOfWork.KoiOrder.GetAllAsync();
            if (koiOrder == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<KoiOrder>());
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, koiOrder);
            }
        }

        public async Task<IBusinessResult> GetById(Guid code)
        {
            var koiOrder = await _unitOfWork.KoiOrder.GetByIdAsync(code);
            if (koiOrder == null)
            {
                return new BusinessResult(Const.FAIL_READ_CODE, Const.FAIL_READ_MSG, new KoiOrder());
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, koiOrder);
            }
        }

        public async Task<IBusinessResult> Save(KoiOrder koiOrder)
        {
            try
            {
                int result = -1;
                var koiOrderTmp = _unitOfWork.KoiOrder.GetById(koiOrder.Id);

                if (koiOrderTmp == null)
                {
                    result = await _unitOfWork.KoiOrder.CreateAsync(koiOrder);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, result);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, new KoiOrder());
                    }
                }
                else
                {
                    result = await _unitOfWork.KoiOrder.UpdateAsync(koiOrder);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, result);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, new KoiOrder());
                    }
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> CreatePayment(RequestPaymentKoiOrderModel koiOrder)
        {
            try
            {
                var orderDetailList = new List<OrderDetail>();
                foreach (var items in koiOrder.OrderDetailList)
                {
                    orderDetailList.Add(new OrderDetail { Id = Guid.NewGuid(), KoiFishId = items.KoiFishId, Price = items.Price });
                }
                var koiOrderEntity = new KoiOrder
                {
                    Id = Guid.NewGuid(),
                    CustomerId = koiOrder.CustomerId,
                    InvoiceId = null,
                    Quantity = koiOrder.Quantity,
                    TotalPrice = koiOrder.TotalPrice,
                    Invoice = new Invoice
                    {
                        Id = Guid.NewGuid(),
                        PaymentAmount = koiOrder.TotalPrice,
                        PaymentDate = DateTime.Now
                    },
                    OrderDetails = orderDetailList
                };

                var koiOrderResult = await _unitOfWork.KoiOrder.CreateAsync(koiOrderEntity);
                if (koiOrderResult == 0)
                {
                    return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, new KoiOrder());
                }
                var momorequest = new RequestCreateOrderModel
                {
                    Buy_date = DateTime.Now,
                    OrderId = koiOrderEntity.Id,
                    OrderType = "KoiOrder",
                    Price = (decimal)koiOrder.TotalPrice,
                };
                var result = await _paymentService.CreatePaymentAsync(momorequest);
               
                return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, result);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
    }
}
