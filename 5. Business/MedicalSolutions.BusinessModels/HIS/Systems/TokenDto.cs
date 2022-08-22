using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.BusinessModels.HIS.Systems
{
    public class TokenDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Jti { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime IssueAt { get; set; }
        public DateTime ExpiredAt { get; set; }
        public string AcceptToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
