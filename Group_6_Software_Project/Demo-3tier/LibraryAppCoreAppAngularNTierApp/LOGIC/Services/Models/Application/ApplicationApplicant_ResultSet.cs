using LOGIC.Services.Models.Applicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.Application
{
    //Custom result set purely for the transaction method for adding both an applicant and application at the same time;
    public class ApplicationApplicant_ResultSet
    {
        public Application_ResultSet application_ResultSet { get; set; }
        public Applicant_ResultSet applicant_ResultSet { get; set; }
    }
}
