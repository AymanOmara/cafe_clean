using System;
namespace Cafe.Application.Services.Authentication.Query
{
    public record ChangePasswordRequest(string CurrentPassword, string NewPassword);
}

