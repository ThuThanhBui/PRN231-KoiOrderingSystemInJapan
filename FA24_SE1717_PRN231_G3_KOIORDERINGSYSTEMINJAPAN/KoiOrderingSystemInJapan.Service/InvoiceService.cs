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
    public interface IInvoiceService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(Guid id);
        Task<IBusinessResult> Save(Invoice invoice);
        Task<IBusinessResult> DeleteById(Guid id);
    }
    public class InvoiceService : IInvoiceService
    {
        private readonly UnitOfWork _unitOfWork;
        public InvoiceService()
        {
            _unitOfWork ??= new UnitOfWork();
        }
        public async Task<IBusinessResult> DeleteById(Guid code)
        {
            try
            {
                var invoice = await _unitOfWork.Invoice.GetByIdAsync(code);
                if (invoice == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new Invoice());
                }
                else
                {
                    var result = await _unitOfWork.Invoice.RemoveAsync(invoice);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, invoice);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, invoice);
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
            var invoice = await _unitOfWork.Invoice.GetAllAsync();
            if (invoice == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<Invoice>());
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, invoice);
            }
        }

        public async Task<IBusinessResult> GetById(Guid code)
        {
            var invoice = await _unitOfWork.Invoice.GetByIdAsync(code);
            if (invoice == null)
            {
                return new BusinessResult(Const.FAIL_READ_CODE, Const.FAIL_READ_MSG, new Invoice());
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, invoice);
            }
        }

        public async Task<IBusinessResult> Save(Invoice invoice)
        {
            try
            {
                int result = -1;
                var invoiceTmp = _unitOfWork.Invoice.GetById(invoice.Id);

                if (invoiceTmp == null)
                {
                    result = await _unitOfWork.Invoice.CreateAsync(invoice);
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
                    result = await _unitOfWork.Invoice.UpdateAsync(invoice);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, result);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, new Invoice());
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
