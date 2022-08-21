using MedicalSolutions.BusinessModels.Common;
using MedicalSolutions.BusinessModels.HIS.Dictionary;
using MedicalSolutions.DataAccess.DAO.HIS.Dictionary;
using MedicalSolutions.DataAccess.IDAO.HIS.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.Business.Facade.HIS.Dictionary
{
    public class UserFacade
    {
        private readonly static IUserDAO userDAO;

        static UserFacade()
        {
            userDAO = new UserDAO();
        }

        public UserFacade()
        {

        }

        public async Task<ResultDto<bool>> Delete(Guid userId)
        {
            return await userDAO.Delete(userId);
        }

        public async Task<ResultDto<UserDto>> GetById(Guid userId)
        {
            return await userDAO.GetById(userId);
        }

        public async Task<ResultDto<UserDto>> GetByUser(UserDto user)
        {
            return await userDAO.GetByUser(user);
        }

        public async Task<ResultDto<List<UserDto>>> GetList()
        {
            return await userDAO.GetList();
        }

        public async Task<ResultDto<UserDto>> Inserṭ(UserDto user)
        {
            return await userDAO.Inserṭ(user); 
        }

        public async Task<ResultDto<UserDto>> Update(UserDto user)
        {
            return await userDAO.Update(user);
        }
    }
}
