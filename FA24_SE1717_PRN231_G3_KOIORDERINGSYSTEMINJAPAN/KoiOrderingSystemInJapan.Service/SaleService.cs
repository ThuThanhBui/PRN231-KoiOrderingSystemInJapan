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
                var e = await unitOfWork.Sale.GetByIdAsync(id);

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

                var e = unitOfWork.User.GetById(sale.Id);

                if (e != null)
                {
                    result = await unitOfWork.Sale.UpdateAsync(sale);

                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    result = await unitOfWork.Sale.CreateAsync(sale);

                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
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
    }
}
