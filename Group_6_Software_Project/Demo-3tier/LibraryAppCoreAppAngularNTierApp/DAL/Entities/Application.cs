using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Application
    {
        public Int64 ApplicationID { get; set; } //(PK)
        public Int64 ApplicantID { get; set; } //(FK)
        public Int64 GradeID { get; set; } //(FK)
        public Int64 ApplicationStatusID { get; set; } //(FK)
        public DateTime Application_CreationDate { get; set; }
        public DateTime Application_ModifiedDate { get; set; }
        public Int32 SchoolYear { get; set; }// THE YEAR THEY APPLYING TO START AT THE SCHOOL FOR

        //RELATIONSHIPS
        //Each Application belongs to a specific Applicant: Applicant_ID
        public Applicant Applicant { get; set; }

        //Each Application is applying for a specific Grade: Grade_ID
        public Grade Grade { get; set; }

        // Each Application is in one status at a time.
        // The status can be changed...
        // But it can only ever be linked to 1 at a time within an application: ApplicationStatus_ID
        public ApplicationStatus ApplicationStatus { get; set; }
    }
}
