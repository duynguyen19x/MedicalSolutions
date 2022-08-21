using MedicalSolutions.BusinessModels.Common;
using MedicalSolutions.BusinessModels.HIS.Dictionary;
using MedicalSolutions.DataAccess.IDAO.HIS.Dictionary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.DataAccess.DAO.HIS.Dictionary
{
    public class UserDAO : IUserDAO
    {
        public async Task<ResultDto<Guid>> Delete(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultDto<UserDto>> GetById(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultDto<List<UserDto>>> GetList()
        {
            throw new NotImplementedException();
        }

        public async Task<ResultDto<UserDto>> Inserṭ(UserDto user)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultDto<UserDto>> Update(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
