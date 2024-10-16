using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;

namespace KoiOrderingSystemInJapan.Service
{
    public interface ISaleService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(Guid id);
        Task<IBusinessResult> Create(Sale sale);
        Task<IBusinessResult> Update(Sale sale);
        Task<IBusinessResult> UpdateIsDeleted(Guid id);
        Task<IBusinessResult> Save(Sale sale);
        Task<IBusinessResult> DeleteById(Guid id);
    }
    public class SaleService : ISaleService
    {
        private readonly UnitOfWork unitOfWork;
        public SaleService()
        {
            unitOfWork ??= new UnitOfWork();
        }
        public Task<IBusinessResult> Create(Sale sale)
        {
            throw new NotImplementedException();
        }

        public async Task<IBusinessResult> DeleteById(Guid id)
        {
            try
            {
                var e = await unitOfWork.Sale.GetByIdAsync(id);

                if (e == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    bool rs = await unitOfWork.Sale.RemoveAsync(e);

                    if (rs)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG);
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
            var sales = await unitOfWork.Sale.GetAllAsync();
            if (sales == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<Sale>());
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, sales);
            }
        }

        public async Task<IBusinessResult> GetById(Guid id)
        {
            try
            {
                var e = await unitOfWork.Sale.GetByIdIncludeAsync(id);

                if (e == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new Sale());
                }
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, e);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> Save(Sale sale)
        {
            try
            {
                int result = -1;
                var saleTmp = unitOfWork.Sale.GetById(sale.Id);

                if (saleTmp == null)
                {
                    result = await unitOfWork.Sale.CreateAsync(sale);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, sale);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, new Sale());
                    }
                }
                else
                {
                    unitOfWork.Sale.Context().Entry(saleTmp).CurrentValues.SetValues(sale);
                    result = await unitOfWork.Sale.UpdateAsync(saleTmp);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, sale);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, new Sale());
                    }
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
        public Task<IBusinessResult> Update(Sale sale)
        {
            throw new NotImplementedException();
        }

        public async Task<IBusinessResult> UpdateIsDeleted(Guid id)
        {
            try
            {
                var e = await unitOfWork.Sale.GetByIdAsync(id);

                if (e == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    bool rs = await unitOfWork.Sale.UpdateIsDeleted(e);

                    if (rs)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
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
    
