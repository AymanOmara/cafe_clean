namespace Cafe.Domain.Core.Models
{
    public record AuthenticationResponse(
        string Token,
        string RefreshToken
    );
}
