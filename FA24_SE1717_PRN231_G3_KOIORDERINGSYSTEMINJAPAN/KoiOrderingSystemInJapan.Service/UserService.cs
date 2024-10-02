using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service.Base;

namespace KoiOrderingSystemInJapan.Service
{
    public interface IUserService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> Create(User user);
        Task<IBusinessResult> Update(User user);
        Task<IBusinessResult> Save(User user);
        Task<IBusinessResult> DeleteById(Guid id);
    }
    public class UserService : IUserService
    {
        private readonly UnitOfWork unitOfWork;
        public UserService()
        {
            unitOfWork ??= new UnitOfWork();
        }
        public Task<IBusinessResult> Create(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<IBusinessResult> DeleteById(Guid id)
        {
            try
            {
                var u = await unitOfWork.User.GetByIdAsync(id);

                if (u == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    bool rs = await unitOfWork.User.RemoveAsync(u);

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
            var users = await unitOfWork.User.GetAllAsync();
            if (users == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<User>());
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, users);
            }
        }

        public async Task<IBusinessResult> GetById(int id)
        {
            try
            {
                var u = await unitOfWork.User.GetByIdAsync(id);

                if (u == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new User());
                }
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, u);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> Save(User user)
        {
            try
            {
                int result = -1;

                var u = unitOfWork.User.GetById(user.Id);

                if (u != null)
                {
                    result = await unitOfWork.User.UpdateAsync(user);

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
                    result = await unitOfWork.User.CreateAsync(user);

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

        public Task<IBusinessResult> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
