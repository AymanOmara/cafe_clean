using Cafe.Application.Common;
using Cafe.Contracts.Core;
using Cafe.Domain.Features.Employees;
using MediatR;

namespace Cafe.Application.Services.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, BaseResponse<EmployeeEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<EmployeeEntity>> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Employees.CreateEmployee(command.ToEntity());
            return new BaseResponse<EmployeeEntity>
            {
                Data = result,
                StatusCode = 200,
                Success = true,
            };
        }
    }
}

