using MedicalSolutions.DataAccess.DAO.HIS.Dictionary;
using MedicalSolutions.DataAccess.IDAO;
using MedicalSolutions.DataAccess.IDAO.HIS.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.DataAccess.DAO
{
    internal class DaoFactory : IDaoFactory
    {
        public IUserDao UserDAO => new UserDao();
    }
}
