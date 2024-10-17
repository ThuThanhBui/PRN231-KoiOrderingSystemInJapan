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
    public interface IFishService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(Guid id);
        Task<IBusinessResult> Create(KoiFish fish);
        Task<IBusinessResult> Update(KoiFish fish);
        Task<IBusinessResult> Save(KoiFish fish);
        Task<IBusinessResult> DeleteById(Guid id);
    }
    public class KoiFishService : IFishService
    {
        private readonly UnitOfWork _unitOfWork;
        public KoiFishService()
        {
            _unitOfWork = new UnitOfWork();
        }
        public Task<IBusinessResult> Create(KoiFish fish)
        {
            throw new NotImplementedException();
        }
        public Task<IBusinessResult> Update(KoiFish fish)
        {
            throw new NotImplementedException();
        }
       
        public async Task<IBusinessResult> GetAll()
        {
            var result = await _unitOfWork.KoiFish.GetAllAsync();
            if (result != null)
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, result);
            }
            else
            {
                return new BusinessResult(Const.FAIL_READ_CODE, Const.FAIL_READ_MSG);
            }
        }

        public async Task<IBusinessResult> GetById(Guid id)
        {
            var result = await _unitOfWork.KoiFish.GetByIdAsync(id);
            if (result != null)
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, result);
            }
            else
            {
                return new BusinessResult(Const.FAIL_READ_CODE, Const.FAIL_READ_MSG);
            }
        }

        public async Task<IBusinessResult> Save(KoiFish fish)
        {
            try
            {
                int result = -1;
                var invoiceTmp = _unitOfWork.KoiFish.GetById(fish.Id);

                if (invoiceTmp == null)
                {
                    result = await _unitOfWork.KoiFish.CreateAsync(fish);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, result);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, new KoiFish());
                    }
                }
                else
                {
                    result = await _unitOfWork.KoiFish.UpdateAsync(fish);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, result);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, new KoiFish());
                    }
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
        public async Task<IBusinessResult> DeleteById(Guid id)
        {
            try
            {
                var fish = await _unitOfWork.KoiFish.GetByIdAsync(id);
                if (fish != null)
                {
                    var result = await _unitOfWork.KoiFish.RemoveAsync(fish);
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

    }
}
