using Cafe.Application.Common;
using Cafe.Domain.Features.User;
using Cafe.Shared.Localization;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Cafe.Application.Services.Authentication.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, BaseResponse<bool>>
    {
        private readonly UserManager<RawaanUser> _userManager;
        private readonly LanguageService _localization;
        public ChangePasswordCommandHandler(UserManager<RawaanUser> userManager, LanguageService localization)
        {
            _userManager = userManager;
            _localization = localization;
        }

        public async Task<BaseResponse<bool>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.UserName))
            {
                return new BaseResponse<bool>
                {
                    StatusCode = 400,
                    Message = _localization.GetKey("user_name_required").Value
                };
            }
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return new BaseResponse<bool>
                {
                    StatusCode = 400,
                    Message = _localization.GetKey("user_not_found").Value,
                };
            }
            var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.newPassword);
            if (result.Succeeded)
            {
                return new BaseResponse<bool>
                {
                    Success = true,
                    StatusCode = 200,
                    Data = true,
                    Message = _localization.GetKey("password_changed_successfully").Value
                };
            }
            return new BaseResponse<bool>
            {
                StatusCode = 400,
                Message = _localization.GetKey("current_password_incorrect").Value
            };

        }
    }
}

