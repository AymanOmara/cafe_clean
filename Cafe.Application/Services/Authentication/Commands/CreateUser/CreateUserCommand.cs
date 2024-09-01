using Cafe.Application.Common;
using MediatR;

namespace Cafe.Application.Services.Authentication.Commands.CreateUser
{
    public record CreateUserCommand(string UserName, string Password, int Role) : IRequest<BaseResponse<bool>>;
}