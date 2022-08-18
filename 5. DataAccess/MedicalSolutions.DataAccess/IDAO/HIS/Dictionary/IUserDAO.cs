using MedicalSolutions.BusinessModels.Common;
using MedicalSolutions.BusinessModels.HIS.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.DataAccess.IDAO.HIS.Dictionary
{
    public interface IUserDAO : IBaseDao
    {
        public ResultDto Inserṭ(UserDto user);
        public ResultDto Update(UserDto user);
        public ResultDto Delete(Guid userId);
        public ResultDto GetList();
        public ResultDto GetById(Guid userId);
    }
}
