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
        // Validate the user credentials
        var user = _context.Accounts
            .FirstOrDefault(u => u.Username == username && u.EncryptedPassword == EncryptPassword(password));

        if (user == null)
        {
            return null; // Invalid credentials
        }

        // Generate JWT token
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.AccountType)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private string EncryptPassword(string password)
    {
        // Implement your password encryption logic here
        return password;
    }
}
