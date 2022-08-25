using MedicalSolutions.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.Models.HIS.Systems
{
    public class LoginModel: BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
