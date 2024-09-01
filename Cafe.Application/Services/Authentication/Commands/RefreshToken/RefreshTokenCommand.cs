using Cafe.Application.Common;
using Cafe.Application.Services.Authentication.Response;
using MediatR;

namespace Cafe.Application.Services.Authentication.Commands.RefreshToken
{
	public class RefreshTokenCommand : IRequest<BaseResponse<LoginResponse>>
	{
		public string? Token { get; set; }

		public string? RefreshToken { get; set; }

	}
}