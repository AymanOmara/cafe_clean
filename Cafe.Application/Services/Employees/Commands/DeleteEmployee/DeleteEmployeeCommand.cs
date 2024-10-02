using Cafe.Application.Common;
using MediatR;

namespace Cafe.Application.Services.Employees.Commands.DeleteEmployee
{
    public record DeleteEmployeeCommand(int id) : IRequest<BaseResponse<bool>>;
}