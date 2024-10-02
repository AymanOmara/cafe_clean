using Cafe.Application.Common;
using Cafe.Contracts.Core;
using Cafe.Domain.Features.Employees;
using MediatR;

namespace Cafe.Application.Services.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, BaseResponse<EmployeeEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<EmployeeEntity>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Employees.UpdateEmployee(request.Employee);
            return new BaseResponse<EmployeeEntity>
            {
                Data = result,
                StatusCode = 200,
                Success = true,
            };
        }
    }
}

