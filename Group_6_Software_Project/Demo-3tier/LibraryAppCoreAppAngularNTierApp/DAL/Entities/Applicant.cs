using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Applicant
    {
        public Int64 ApplicantID { get; set; } //(PK)
        public String Applicant_Name { get; set; }
        public String Applicant_Surname { get; set; }
        public DateTime Applicant_BirthDate { get; set; }
        public String Contact_Email { get; set; }
        public String Contact_Number { get; set; }
        public DateTime Applicant_CreationDate { get; set; }
        public DateTime Applicant_ModifiedDate { get; set; }

        //RELATIONSHIPS
        // An applicant can have many applications, they could apply every year and never get in
        // An Application though belongs to only 1 applicant at a time.
        public ICollection<Application> Applications { get; set; }
    }
}
