using Cafe.Application.Common;
using MediatR;

namespace Cafe.Application.Services.Authentication.Commands.DeleteUser
{
    public record DeleteUserCommand(string UserName) : IRequest<BaseResponse<bool>>;

}

