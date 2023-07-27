namespace MVC_Enrolment_demo.Models
{
	public class UpdateEmployeeViewModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Age { get; set; }
		public DateTime DOB { get; set; }
		public string Course { get; set; }
	}
}
