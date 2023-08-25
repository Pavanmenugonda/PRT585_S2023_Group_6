using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.Applicant
{
    //NON DB ENTITIES IM USING LOWER CASE.
    public class Applicant_ResultSet
    {
        public Int64 id { get; set; }
        public String name { get; set; }
        public String surname { get; set; }
        public DateTime birthday { get; set; }
        public String email { get; set; }
        public String phone_number { get; set; }
        public DateTime submission_date { get; set; }
    }
}
