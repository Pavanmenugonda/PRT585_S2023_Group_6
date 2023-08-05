namespace Web_API_tut_1.Models
{
    public class AddContactRequest
    {
        public string FullName { get; set; }

        public string Gender { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
