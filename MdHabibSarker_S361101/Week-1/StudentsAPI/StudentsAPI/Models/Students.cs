using System.ComponentModel.DataAnnotations;

namespace StudentsAPI.Models
{
    public class Students
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Major { get; set; }
    }
}
