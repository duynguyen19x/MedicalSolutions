using MedicalSolutions.IProviders.HIS.Dictionary;
using MedicalSolutions.Models.HIS.Dictionary;
using MedicalSolutions.Util.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.Providers.HIS.Dictionary
{
    public class UserProvider : IUserProvider
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

        public ResultApp Login()
        {
            var resultApp = new ResultApp();

            try
            {
                resultApp = AppApi.PostAsync<ResultApp, UserModel>("https://localhost:7107/api/User/Login", new UserModel() 
                { 
                    Id = Guid.NewGuid(),
                    UserName = "Admin",
                    FullName = "Admin",
                    Email = "Admin@gmail.com",
                    PhoneNumber = "123456789",
                });
            }
            catch (Exception ex)
            {
                resultApp.Message = ex.Message;
            }

            return resultApp;
        }
    }
}
