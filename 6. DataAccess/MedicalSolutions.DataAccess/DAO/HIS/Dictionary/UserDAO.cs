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
    public class UserDao : IUserDao
    {
        public async Task<ResultDto<bool>> Delete(Guid userId)
        {
            var resultDto = new ResultDto<bool>();

            return await Task.FromResult(resultDto);
        }

        public async Task<ResultDto<UserDto>> GetByUser(UserDto user)
        {
            var resultDto = new ResultDto<UserDto>();

            return await Task.FromResult(resultDto);
        }

        public async Task<ResultDto<UserDto>> GetByUserName(string username, string password)
        {
            var resultDto = new ResultDto<UserDto>() { Result = new UserDto() };

            return await Task.FromResult(resultDto);
        }

        public async Task<ResultDto<UserDto>> GetById(Guid userId)
        {
            var resultDto = new ResultDto<UserDto>();

            return await Task.FromResult(resultDto);
        }

        public async Task<ResultDto<List<UserDto>>> GetList()
        {
            var resultDto = new ResultDto<List<UserDto>>();

            return await Task.FromResult(resultDto);
        }

        public async Task<ResultDto<UserDto>> Inserṭ(UserDto user)
        {
            var resultDto = new ResultDto<UserDto>();

            return await Task.FromResult(resultDto);
        }

        public async Task<ResultDto<UserDto>> Update(UserDto user)
        {
            var resultDto = new ResultDto<UserDto>();

            return await Task.FromResult(resultDto);
        }
    }
}
