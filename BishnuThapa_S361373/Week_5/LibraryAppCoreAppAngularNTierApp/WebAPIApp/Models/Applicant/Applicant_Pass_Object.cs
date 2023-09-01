using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_API.Models.Applicant
{
    public class Applicant_Pass_Object
    {
        public String name { get; set; }
        public String surname { get; set; }
        public DateTime birthday { get; set; }
        public String email { get; set; }
        public String phone_number { get; set; }
    }
}
