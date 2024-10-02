using Cafe.Application.Common;
using Cafe.Application.Services.Employees.Employees.Query;
using Cafe.Contracts.Core;
using Cafe.Domain.Features.Employees;
using MediatR;

namespace Cafe.Application.Services.Employees.Query.Employees
{
    public class EmployeesQueryHandler : IRequestHandler<EmployeesQuery, BaseResponse<ICollection<EmployeeEntity>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<ICollection<EmployeeEntity>>> Handle(EmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _unitOfWork.Employees.GetEmployees();
            return new BaseResponse<ICollection<EmployeeEntity>>
            {
                Data = employees,
                StatusCode = 200,
                Success = true,
            };
        }
    }
}