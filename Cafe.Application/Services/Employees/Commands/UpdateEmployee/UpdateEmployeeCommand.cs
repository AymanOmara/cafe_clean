using Cafe.Application.Common;
using Cafe.Domain.Features.Employees;
using MediatR;

namespace Cafe.Application.Services.Employees.Commands.UpdateEmployee
{
	public record UpdateEmployeeCommand(EmployeeEntity Employee):IRequest<BaseResponse<EmployeeEntity>>;
	
}

