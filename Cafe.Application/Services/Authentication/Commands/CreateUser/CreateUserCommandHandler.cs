using Cafe.Application.Common;
using Cafe.Contracts.Core;
using Cafe.Domain.Features.User;
using Cafe.Shared.Localization;
using MediatR;

namespace Cafe.Application.Services.Authentication.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly LanguageService _localization;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork,
            LanguageService localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<BaseResponse<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.UserName))
            {
                return new BaseResponse<bool>
                {
                    StatusCode = 400,
                    Message = _localization.GetKey("username_required").Value
                };
            };

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return new BaseResponse<bool>
                {
                    StatusCode = 400,
                    Message = _localization.GetKey("password_required").Value
                };
            };

            if (request.Password.Length < 4)
            {
                return new BaseResponse<bool>
                {
                    StatusCode = 400,
                    Message = _localization.GetKey("poor_password").Value
                };
            };
            if (!Enum.IsDefined(typeof(CafeRoles), request.Role))
            {
                return new BaseResponse<bool>
                {
                    StatusCode = 400,
                    Message = _localization.GetKey("invalid_role_number").Value
                };
            };
            var result = await _unitOfWork
                .Authentication
                .CreateUser(
                UserName: request.UserName,
                Password: request.Password,
                RoleId: request.Role);
            return new BaseResponse<bool>
            {
                StatusCode = 200,
                Message = _localization.GetKey("user_created_successfully").Value,
                Success = result,
                Data = result
            };
        }
    }
}