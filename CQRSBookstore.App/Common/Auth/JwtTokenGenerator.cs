using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CQRSBookstore.App.Common.interfaces.Account;
using CQRSBookstore.App.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CQRSBookstore.App.Common.Auth;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtOptions)
    {
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Email.ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: DateTime.Now.AddDays(30),
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public string Secret { get; init; } =
        "mySecret is wayt to product this is ha ha!!! wow I lov it sser this is the wge";
    public int ExpiryMinutes { get; init; }
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
}
