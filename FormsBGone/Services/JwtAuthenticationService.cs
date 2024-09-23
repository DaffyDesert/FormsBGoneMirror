namespace FormsBGone.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FormsBGone.Model;

public class JwtAuthenticationService
{
    private readonly CapstoneContext _context;
    private readonly IConfiguration _configuration;

    public JwtAuthenticationService(CapstoneContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public string Authenticate(string username, string password)
    {
        var user = _context.Accounts
            .FirstOrDefault(u => u.Username == username && u.EncryptedPassword == EncryptPassword(password));

        if (user == null)
        {
            return null; // Invalid credentials
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

        // Ensure that ValidIssuer and ValidAudience are set correctly here
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim("role", user.AccountType)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _configuration["Jwt:Issuer"],  // Add Issuer
            Audience = _configuration["Jwt:Audience"]  // Add Audience
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }


    private string EncryptPassword(string password)
    {
        // Implement your password encryption logic here
        return password; // Placeholder
    }
}
