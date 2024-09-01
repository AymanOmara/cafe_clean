using Cafe.Application.Common;
using Cafe.Application.Services.Authentication.Response;
using Cafe.Contracts.Core;
using Cafe.Domain.Features.User;
using Cafe.Shared.Localization;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Cafe.Application.Services.Authentication.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, BaseResponse<LoginResponse>>
    {
        private readonly LanguageService _localization;
        private readonly IUnitOfWork _unitOfWork;
        public readonly UserManager<RawaanUser> _userManager;

        public RefreshTokenCommandHandler(LanguageService localization, IUnitOfWork unitOfWork, UserManager<RawaanUser> userManager)
        {
            _localization = localization;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<BaseResponse<LoginResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Token))
            {
                return new BaseResponse<LoginResponse> { StatusCode = 400, Message = _localization.GetKey("token_required").Value };
            };

            if (string.IsNullOrWhiteSpace(request.RefreshToken))
            {
                return new BaseResponse<LoginResponse> { StatusCode = 400, Message = _localization.GetKey("refreh_token_required").Value };
            };
            var user = await _unitOfWork.Authentication.GetUserByRefreshToken(RefreshToken:request.RefreshToken);
            
            if (user == null || !user.RefreshToken.Equals(request.RefreshToken))
            {
                return new BaseResponse<LoginResponse> { StatusCode = 400, Message = _localization.GetKey("login_required").Value };
            }
            var authenticationResponse = await _unitOfWork.Authentication.Login(user);
            return new BaseResponse<LoginResponse>
            {
                StatusCode = 200,
                Message = _localization.GetKey("token_refreshed_successfully").Value,
                Data = new LoginResponse(Token:
                authenticationResponse.Token,
                RefreshToken: authenticationResponse.RefreshToken)
            };
        }
    }
}