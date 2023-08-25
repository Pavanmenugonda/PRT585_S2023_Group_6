using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.Application
{
    public class Application_ResultSet
    {
        public Int64 id { get; set; } //(PK)
        public Int64 applicant_id { get; set; } //(FK)
        public Int64 grade_id { get; set; } //(FK)
        public Int64 status_id { get; set; } //(FK)
        public DateTime submission_date { get; set; }
        public Int32 school_year { get; set; }// THE YEAR THEY APPLYING TO START AT THE SCHOOL FOR
    }
}
