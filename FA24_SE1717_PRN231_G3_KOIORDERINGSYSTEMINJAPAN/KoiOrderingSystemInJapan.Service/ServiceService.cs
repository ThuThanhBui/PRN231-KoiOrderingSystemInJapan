﻿using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data;
using KoiOrderingSystemInJapan.Service.Base;
using ServiceEntity = KoiOrderingSystemInJapan.Data.Models;
namespace KoiOrderingSystemInJapan.Service
{
    public interface IServiceService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(Guid id);
        Task<IBusinessResult> Save(ServiceEntity.Service service);
        Task<IBusinessResult> DeleteById(Guid id);
    }
    public class ServiceService : IServiceService
    {
        private readonly UnitOfWork _unitOfWork;
        public ServiceService()
        {
            _unitOfWork ??= new UnitOfWork();
        }
        public async Task<IBusinessResult> DeleteById(Guid code)
        {
            try
            {
                var service = await _unitOfWork.Service.GetByIdAsync(code);
                if (service == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new ServiceEntity.Service());
                }
                else
                {
                    var result = await _unitOfWork.Service.RemoveAsync(service);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, service);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, service);
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
            var service = await _unitOfWork.Service.GetAllAsync();
            if (service == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<ServiceEntity.Service>());
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, service);
            }
        }

        public async Task<IBusinessResult> GetById(Guid code)
        {
            var service = await _unitOfWork.Service.GetByIdAsync(code);
            if (service == null)
            {
                return new BusinessResult(Const.FAIL_READ_CODE, Const.FAIL_READ_MSG, new ServiceEntity.Service());
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, service);
            }
        }

        public async Task<IBusinessResult> Save(ServiceEntity.Service service)
        {
            try
            {
                int result = -1;
                var serviceTmp = _unitOfWork.Service.GetById(service.Id);

                if (serviceTmp == null)
                {
                    result = await _unitOfWork.Service.CreateAsync(service);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, result);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, new ServiceEntity.Service());
                    }
                }
                else
                {
                    result = await _unitOfWork.Service.UpdateAsync(service);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, result);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, new ServiceEntity.Service());
                    }
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

    }
}
