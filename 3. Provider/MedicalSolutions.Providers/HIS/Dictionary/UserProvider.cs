using MedicalSolutions.IProviders.HIS.Dictionary;
using MedicalSolutions.Util.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.Providers.HIS.Dictionary
{
    internal class UserProvider : IUserProvider
    {
        public ResultApp GetList()
        {
            var resultApp = new ResultApp();

            try
            {
                resultApp = AppApi.GetAsync<ResultApp>("api/User/GetList");
            }
            catch (Exception ex)
            {
                resultApp.Message = ex.Message;
            }

            return resultApp;
        }
    }
}
