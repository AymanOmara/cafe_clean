using Cafe.Contracts.Features.Employee;
using Cafe.Domain.Features.Employees;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly RawaanDBContext _context;

        public EmployeeRepository(RawaanDBContext context)
        {
            _context = context;
        }

        public async Task<EmployeeEntity> CreateEmployee(EmployeeEntity employee)
        {
            await _context.Employees.AddAsync(entity: employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<ICollection<EmployeeEntity>> GetEmployees()
        {
            var emoployees = await _context.Employees.ToListAsync();
            return emoployees;
        }
        public async Task<bool> DeleteEmployee(int id)
        {
            await _context.Employees
                .Where(emp => emp.Id == id)
                .ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<EmployeeEntity> UpdateEmployee(EmployeeEntity employee)
        {
            await _context.Employees
                .Where(emp => emp.Id == employee.Id)
                .ExecuteUpdateAsync(emp => emp
                .SetProperty(z => z.Name, employee.Name)
                .SetProperty(z => z.Age, employee.Age)
                .SetProperty(z => z.PhoneNumber, employee.PhoneNumber)
                );
            await _context.SaveChangesAsync();
            return employee;
        }
    }
}