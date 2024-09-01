namespace Cafe.Contracts.Features.Authentication
{
    public record LoginRequest(
        string UserName,
        string Password
        );
}