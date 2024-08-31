using Cafe.Api.Utils;
using Cafe.Application.Services.Authentication.Commands.Login;
using Cafe.Contracts.Features.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Cafe.Api.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public class AuthenticationController: ControllerBase
    {
		private readonly IMediator _meadiator;

		public AuthenticationController(IMediator meadiator)
		{
			_meadiator = meadiator;
		}
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest) {
			var result = await _meadiator.Send(new LoginCommand(UserName:loginRequest.UserName,Password:loginRequest.Password));
			return result.ToResult();
		}
	}
}