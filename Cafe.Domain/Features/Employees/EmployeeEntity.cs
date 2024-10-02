namespace Cafe.Domain.Features.Employees
{
	public class EmployeeEntity
	{

		public int Id { get; set; }

		public string PhoneNumber { get; set; } = string.Empty;

		public int Age { get; set; }

		public string Name { get; set; } = string.Empty;
    }
}