namespace Cafe.Application.Services.Authentication.Response
{
    public record LoginResponse(
        string Token,
        string RefreshToken
        );

}

