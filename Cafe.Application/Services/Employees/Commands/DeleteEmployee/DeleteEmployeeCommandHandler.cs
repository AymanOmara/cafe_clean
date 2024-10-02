using Cafe.Application.Common;
using Cafe.Contracts.Core;
using MediatR;

namespace Cafe.Application.Services.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Employees.DeleteEmployee(request.id);
            return new BaseResponse<bool>
            {
                Data = true,
                StatusCode = 200,
                Success = true,
            };
        }
    }
}

