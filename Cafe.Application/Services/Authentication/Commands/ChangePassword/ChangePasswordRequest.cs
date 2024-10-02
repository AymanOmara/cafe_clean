namespace Cafe.Application.Services.Authentication.Commands.ChangePassword
{
    public record ChangePasswordRequest(string CurrentPassword, string NewPassword);
}