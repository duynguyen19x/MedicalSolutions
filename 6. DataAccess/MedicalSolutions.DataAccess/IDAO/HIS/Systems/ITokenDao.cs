using MedicalSolutions.BusinessModels.HIS.Systems;
using MedicalSolutions.DataAccess.DAO.HIS.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.DataAccess.IDAO.HIS.Systems
{
    public interface ITokenDao
    {
        Task<bool> Insert(TokenDto token);
        Task<bool> Update(TokenDto token);
        Task<TokenDto> Get(string refreshToken);
    }
}
