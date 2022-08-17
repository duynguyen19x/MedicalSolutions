using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.BusinessModels.Common
{
    public class ResultDto
    {
        public object Result { get; set; }
        public string Message { get; set; }
        public Guid? ResultId { get; set; }
        public int? Status { get; set; }
    }
}
