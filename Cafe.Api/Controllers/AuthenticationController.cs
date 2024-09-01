using System.Security.Claims;
using Cafe.Api.Utils;
using Cafe.Application.Services.Authentication.Commands.ChangePassword;
using Cafe.Application.Services.Authentication.Commands.CreateUser;
using Cafe.Application.Services.Authentication.Commands.DeleteUser;
using Cafe.Application.Services.Authentication.Commands.Login;
using Cafe.Application.Services.Authentication.Commands.RefreshToken;
using Cafe.Application.Services.Authentication.Query;
using Cafe.Application.Services.Authentication.Response;
using Cafe.Contracts.Features.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Cafe.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _meadiator;

        public AuthenticationController(IMediator meadiator)
        {
            _meadiator = meadiator;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var result = await _meadiator.Send(new LoginCommand(UserName: loginRequest.UserName, Password: loginRequest.Password));
            return result.ToResult();
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] LoginResponse token)
        {
            var result = await _meadiator.Send(new RefreshTokenCommand
            {
                Token = token.Token,
                RefreshToken = token.RefreshToken,
            });
            return result.ToResult();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _meadiator.Send(command);
            return result.ToResult();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserCommand command)
        {
            var result = await _meadiator.Send(command);
            return result.ToResult();
        }
        [Authorize]
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var UserName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var command = new ChangePasswordCommand(newPassword: request.NewPassword, OldPassword: request.CurrentPassword , UserName: UserName);
            var result = await _meadiator.Send(command);
            return result.ToResult();
        }
    }
}