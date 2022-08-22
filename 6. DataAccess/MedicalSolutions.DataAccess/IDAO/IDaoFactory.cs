using MedicalSolutions.DataAccess.IDAO.HIS.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.DataAccess.IDAO
{
    public interface IDaoFactory
    {
        IUserDao UserDAO { get; }
    }
}
