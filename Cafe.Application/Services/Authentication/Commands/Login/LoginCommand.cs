using Cafe.Application.Common;
using Cafe.Application.Services.Authentication.Response;
using MediatR;

namespace Cafe.Application.Services.Authentication.Commands.Login
{
    public record LoginCommand(
        string UserName,
        string Password
        ) : IRequest<BaseResponse<LoginResponse>>;
}
