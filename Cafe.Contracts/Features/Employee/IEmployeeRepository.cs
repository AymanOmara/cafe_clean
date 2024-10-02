using Cafe.Domain.Features.Employees;

namespace Cafe.Contracts.Features.Employee
{
	public interface IEmployeeRepository
	{
		public Task<ICollection<EmployeeEntity>> GetEmployees();

		public Task<EmployeeEntity> CreateEmployee(EmployeeEntity employee);

		public Task<bool> DeleteEmployee(int id);

        public Task<EmployeeEntity> UpdateEmployee(EmployeeEntity employee);
    }
}