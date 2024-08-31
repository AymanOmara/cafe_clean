﻿using Cafe.Application.Common;
using Cafe.Application.Services.Authentication.Response;
using Cafe.Contracts.Core;
using Cafe.Domain.Features.User;
using Cafe.Shared.Localization;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Cafe.Application.Services.Authentication.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, BaseResponse<LoginResponse>>
    {
        private readonly LanguageService _localization;
        private readonly IUnitOfWork _unitOfWork;
        public readonly UserManager<RawaanUser> _userManager;

        public LoginCommandHandler(LanguageService localization, IUnitOfWork unitOfWork, UserManager<RawaanUser> userManager)
        {
            _localization = localization;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task<BaseResponse<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.UserName))
            {
                return new BaseResponse<LoginResponse> { StatusCode = 400, Message = _localization.GetKey("username_required").Value };
            };

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return new BaseResponse<LoginResponse> { StatusCode = 400, Message = _localization.GetKey("password_required").Value };
            };
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return new BaseResponse<LoginResponse> { StatusCode = 400, Message = _localization.GetKey("invalid_user_name").Value };
            }
            var result = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!result)
            {
                return new BaseResponse<LoginResponse> { StatusCode = 400, Message = _localization.GetKey("invalid_password").Value };

            }
            var authenticationResponse = await _unitOfWork.Authentication.Login(user);
            return new BaseResponse<LoginResponse>
            {
                StatusCode = 200,
                Message = _localization.GetKey("login_successfully").Value,
                Data = new LoginResponse(Token:
                authenticationResponse.Token,
                RefreshToken: authenticationResponse.RefreshToken)
            };
        }
    }
}