using System.ComponentModel.DataAnnotations;

namespace Web_API_tut_1.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } 
        public string Email { get; set; }

        public string Phone { get; set; }
        public long Salary { get; set; }

        public string Department { get; set; }


    }
}
