using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.Models.HIS.Dictionary
{
    public  class UserModel
    {
        public Guid? Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid? GenderId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Guid? ProvinceId { get; set; }
        public Guid? District { get; set; }
        public Guid? WardsId { get; set; }
    }
}
