using MedicalSolutions.BusinessModels.HIS.Systems;
using MedicalSolutions.DataAccess.DAO.HIS.Systems;
using MedicalSolutions.DataAccess.IDAO.HIS.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.Business.Facade.HIS.Systems
{
    public class TokenFacade
    {
        private readonly static ITokenDao _tokenDao;

        static TokenFacade()
        {
            _tokenDao = new TokenDao();
        }

        public async Task<bool> Insert(TokenDto token)
        {
            return await _tokenDao.Insert(token);
        }

        public async Task<bool> Update(TokenDto token)
        {
            return await _tokenDao.Update(token);
        }

        public async Task<TokenDto> Get(string refreshToken)
        {
            return await _tokenDao.Get(refreshToken);
        }
    }
}
