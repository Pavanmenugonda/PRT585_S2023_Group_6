using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Applicant;

namespace WEB_API.Models.Application
{
    public class Application_Pass_Object
    {
        public int applicant_id { get; set; }
        public int grade_id { get; set; }
        public int school_year { get; set; }
        public Applicant_Pass_Object applicant { get; set; }
    }
}
