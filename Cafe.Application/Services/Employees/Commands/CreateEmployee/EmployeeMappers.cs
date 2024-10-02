using Cafe.Domain.Features.Employees;

namespace Cafe.Application.Services.Employees.Commands.CreateEmployee
{
    public static class EmployeeMappers
    {
        public static EmployeeEntity ToEntity(this CreateEmployeeCommand command)
        {
            return new EmployeeEntity
            {
                //Id = command.id,
                Name = command.name,
                Age = command.age,
                PhoneNumber = command.phoneNumber,
            };
        }
    }
}