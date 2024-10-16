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
    public interface IFarmService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetByName(string name);
        Task<IBusinessResult> GetById(Guid id);
        Task<IBusinessResult> Create(Farm farm);
        Task<IBusinessResult> Update(Farm farm);
        Task<IBusinessResult> DeleteById(Guid id);
        Task<IBusinessResult> Save(Farm farm);


    }
    public class FarmService : IFarmService
    {

        private readonly UnitOfWork unitOfWork;

        public FarmService() { unitOfWork ??= new UnitOfWork(); }

        public Task<IBusinessResult> Create(Farm farm)
        {
            throw new NotImplementedException();
        }

        public Task<IBusinessResult> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IBusinessResult> GetAll()
        {
            var farms = await unitOfWork.Farm.GetAllAsync();
            if (farms == null) 
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE,Const.WARNING_NO_DATA_MSG,new List<Farm>());
            } else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE,Const.SUCCESS_READ_MSG,farms);
            }
        }

        public async Task<IBusinessResult> GetById(Guid id)
        {
            try
            {
                var f = await unitOfWork.Farm.GetByIdAsync(id);

                if (f == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new Farm());
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, f);
                }
            }
            catch (Exception ex) 
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public Task<IBusinessResult> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IBusinessResult> Save(Farm farm)
        {
            throw new NotImplementedException();
        }

        public Task<IBusinessResult> Update(Farm farm)
        {
            throw new NotImplementedException();
        }
    }
}
