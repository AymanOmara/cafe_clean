using System;
namespace Cafe.Infrastructure.Common.Authentication
{
	public class JWTSettings
	{
        public const string SectionName = "JwtSettings";

        public string Secret { get; init; } = null!;

        public string Issuer { get; init; } = null!;

        public string Audience { get; init; } = null!;

        public int ExpirationTimeInMinutes { get; init; }
    }
}

