using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service
{

    public interface IDeliveryDetailService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(Guid id);
        Task<IBusinessResult> Create(DeliveryDetail user);
        Task<IBusinessResult> Update(DeliveryDetail user);
        Task<IBusinessResult> Save(DeliveryDetail user);
        Task<IBusinessResult> DeleteById(Guid id);
    }
    public class DeliveryDetailService : IDeliveryDetailService
    {
        private readonly UnitOfWork _unitOfWork;

        public DeliveryDetailService() {
            _unitOfWork ??= new UnitOfWork();
        }
        public Task<IBusinessResult> Create(DeliveryDetail delivery)
        {
            throw new NotImplementedException();
        }

        public async Task<IBusinessResult> DeleteById(Guid id)
        {
            try
            {
                var deliverydetail = await _unitOfWork.DeliveryDetail.GetByIdAsync(id);
                if (deliverydetail != null)
                {
                    var result = await _unitOfWork.DeliveryDetail.RemoveAsync(deliverydetail);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, result);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, result);
                    }
                }
                else
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }

            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetAll()
        {
            var deliverydetail = await _unitOfWork.DeliveryDetail.GetAllAsync();
            if (deliverydetail == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<User>());
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, deliverydetail);
            }
        }

        public async Task<IBusinessResult> GetById(Guid id)
        {
            try
            {
                var u = await _unitOfWork.DeliveryDetail.GetByIdAsync(id);

                if (u == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new DeliveryDetail());
                }
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, u);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> Save(DeliveryDetail detail)
        {
            try
            {
                int result = -1;
                var detailTmp = _unitOfWork.DeliveryDetail.GetById(detail.Id);

                if (detailTmp == null)
                {
                    result = await _unitOfWork.DeliveryDetail.CreateAsync(detail);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, result);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, new DeliveryDetail());
                    }
                }
                else
                {
                    result = await _unitOfWork.DeliveryDetail.UpdateAsync(detail);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, result);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, new DeliveryDetail());
                    }
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public Task<IBusinessResult> Update(DeliveryDetail delivery)
        {
            throw new NotImplementedException();
        }
    }
}
