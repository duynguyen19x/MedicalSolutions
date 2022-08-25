using MedicalSolutions.BusinessModels.HIS.Systems;
using MedicalSolutions.DataAccess.IDAO.HIS.Systems;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.DataAccess.DAO.HIS.Systems
{
    public class TokenDao : ITokenDao
    {
        public async Task<bool> Insert(TokenDto token)
        {
            IConfiguration ss = new ConfigurationManager().GetSection("AppSetting");

            return await Task.FromResult(true);
        }

        public async Task<bool> Update(TokenDto token)
        {
            return await Task.FromResult(true);
        }

        public async Task<TokenDto> Get(string refreshToken)
        {
            return await Task.FromResult(new TokenDto());
        }
    }
}
