using Cafe.Application.Common;
using MediatR;

namespace Cafe.Application.Services.Authentication.Commands.ChangePassword
{
    public record ChangePasswordCommand(string OldPassword, string newPassword, string UserName) : IRequest<BaseResponse<bool>>;
}

