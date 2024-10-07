using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data;
using KoiOrderingSystemInJapan.Data.Models;
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
    public interface IServiceOrderService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(Guid id);
        Task<IBusinessResult> Save(ServiceOrder serviceOrder);
        Task<IBusinessResult> DeleteById(Guid id);
        Task<IBusinessResult> CreatePayment(RequestPaymentServiceModel serviceOrder);
    }
    public class ServiceOrderService : IServiceOrderService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;
        public ServiceOrderService()
        {
            this._unitOfWork ??= new UnitOfWork();
            this._paymentService ??= new PaymentService();
        }

        public async Task<IBusinessResult> DeleteById(Guid code)
        {
            try
            {
                var serviceOrder = await _unitOfWork.ServiceOrder.GetByIdAsync(code);
                if (serviceOrder == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new ServiceOrder());
                }
                else
                {
                    var result = await _unitOfWork.ServiceOrder.RemoveAsync(serviceOrder);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, serviceOrder);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, serviceOrder);
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
            var serviceOrder = await _unitOfWork.ServiceOrder.GetAllAsync();
            if (serviceOrder == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<ServiceOrder>());
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, serviceOrder);
            }
        }
        public async Task<IBusinessResult> GetById(Guid code)
        {
            var serviceOrder = await _unitOfWork.ServiceOrder.GetByIdAsync(code);
            if (serviceOrder == null)
            {
                return new BusinessResult(Const.FAIL_READ_CODE, Const.FAIL_READ_MSG, new ServiceOrder());
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, serviceOrder);
            }
        }

        public async Task<IBusinessResult> Save(ServiceOrder serviceOrder)
        {
            try
            {
                int result = -1;
                var serviceOrderTmp = _unitOfWork.ServiceOrder.GetById(serviceOrder.Id);

                if (serviceOrderTmp == null)
                {
                    result = await _unitOfWork.ServiceOrder.CreateAsync(serviceOrder);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, result);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, new Invoice());
                    }
                }
                else
                {
                    result = await _unitOfWork.ServiceOrder.UpdateAsync(serviceOrder);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, result);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, new ServiceOrder());
                    }
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> CreatePayment(RequestPaymentServiceModel request)
        {
            try
            {
                var serviceOrderEntity = new ServiceOrder
                {
                    Id = Guid.NewGuid(),
                    InvoiceId = null,
                    CustomerServiceId = request.CustomerServiceId,
                    Quantity = request.Quantity,
                    TotalPrice = request.TotalPrice,
                    Invoice = new Invoice
                    {
                        Id= Guid.NewGuid(),
                        PaymentAmount = request.TotalPrice,
                        PaymentDate = DateTime.Now
                    }
                };
                var serviceOrderResult = await _unitOfWork.ServiceOrder.CreateAsync(serviceOrderEntity);

                if(serviceOrderResult == 0)
                {
                    return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, new ServiceOrder());
                }
                var momoRequest = new RequestCreateOrderModel
                {
                   Buy_date = DateTime.Now,
                   OrderId = serviceOrderEntity.Id,
                   OrderType = "ServiceOrder",
                   Price = (decimal)serviceOrderEntity.TotalPrice,
                };
                var result = await _paymentService.CreatePaymentAsync(momoRequest);
                return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, result);

            } catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
    }
}
