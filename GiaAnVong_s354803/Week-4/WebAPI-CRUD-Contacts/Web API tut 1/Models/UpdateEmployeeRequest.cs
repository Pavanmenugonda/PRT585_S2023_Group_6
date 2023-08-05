namespace Web_API_tut_1.Models
{
    public class UpdateEmployeeRequest
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }
        public string Email { get; set; }


        public string Phone { get; set; }
        public long Salary { get; set; }

        public string Department { get; set; }
    }
}
