using Cafe.Application.Common;
using Cafe.Domain.Features.Employees;
using MediatR;

namespace Cafe.Application.Services.Employees.Employees.Query
{
    public record EmployeesQuery : IRequest<BaseResponse<ICollection<EmployeeEntity>>>;
}

