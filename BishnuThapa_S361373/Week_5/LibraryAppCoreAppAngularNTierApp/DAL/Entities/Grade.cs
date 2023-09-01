using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Grade
    {
        public Int64 GradeID { get; set; } //(PK)
        public String Grade_Name { get; set; }
        public Int32 Grade_Number { get; set; }
        public Int32 Grade_Capacity { get; set; }
        public DateTime Grade_CreationDate { get; set; }
        public DateTime Grade_ModifiedDate { get; set; }

        //RELATIONSHIPS
        // When an application is filled out, the applicant needs to specify what grade they applying for.
        // Therefore a grade is linked to multiple applications
        // But Application can only have one grade specified to them at a time.
        public ICollection<Application> Applications { get; set; }
    }
}
