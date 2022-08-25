using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.Util.Common
{
    public class ResultApp
    {
        public object Result { get; set; }
        public string Message { get; set; }
        public int? Status { get; set; }
        public int TotalCount { get; set; }
    }
}
