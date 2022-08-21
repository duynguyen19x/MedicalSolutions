using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.BusinessModels.Common
{
    public class ResultDto<T>
    {
        public T Result { get; set; }
        public string Message { get; set; }
        public int? Status { get; set; }
        public int TotalCount { get; set; }
    }
}
