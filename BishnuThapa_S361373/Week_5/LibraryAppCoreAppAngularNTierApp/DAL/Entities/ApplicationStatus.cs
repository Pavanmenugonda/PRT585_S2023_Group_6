using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ApplicationStatus
    {
        public Int64 ApplicationStatusID { get; set; } //(PK)
        public String ApplicationStatus_Name { get; set; }
        public DateTime ApplicationStatus_CreationDate { get; set; }
        public DateTime ApplicationtStatus_ModifiedDate { get; set; }

        //RELATIONSHIPS
        // An application status can be applied to mulitple applications
        // But Application can only have one application status at a time.
        public ICollection<Application> Applications { get; set; }
    }
}
