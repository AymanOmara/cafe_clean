using Cafe.Application.Common;
using Cafe.Domain.Features.Employees;
using MediatR;

namespace Cafe.Application.Services.Employees.Commands.CreateEmployee
{
    public record CreateEmployeeCommand(
        int id,
        string name,
        string phoneNumber,
        int age) : IRequest<BaseResponse<EmployeeEntity>>;

}