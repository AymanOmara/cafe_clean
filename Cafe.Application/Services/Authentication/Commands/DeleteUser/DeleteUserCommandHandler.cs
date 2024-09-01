using Cafe.Application.Common;
using Cafe.Domain.Features.User;
using Cafe.Shared.Localization;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Cafe.Application.Services.Authentication.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, BaseResponse<bool>>
    {
        private readonly LanguageService _localization;
        private readonly UserManager<RawaanUser> _userManger;
        public DeleteUserCommandHandler(LanguageService localization, UserManager<RawaanUser> userManger)
        {
            _localization = localization;
            _userManger = userManger;

        }

        public async Task<BaseResponse<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.UserName))
            {
                return new BaseResponse<bool>
                {
                    StatusCode = 400,
                    Message = _localization.GetKey("user_name_required").Value
                };
            }
            var user = await _userManger.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return new BaseResponse<bool>
                {
                    StatusCode = 400,
                    Message = _localization.GetKey("user_not_found").Value,
                };
            }
            await _userManger.DeleteAsync(user);
            return new BaseResponse<bool>
            {
                Success = true,
                Message = _localization.GetKey("user_deleted").Value,
                StatusCode = 200,
                Data = true,
            };
        }
    }
}