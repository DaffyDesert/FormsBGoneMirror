﻿using FormsBGone.DTOs;
using static FormsBGone.Responses.CustomResponses;
using FormsBGone.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using FormsBGone.States;
using System.Linq.Expressions;

namespace FormsBGone.Repos
{
    public class AccountLogin : IAccountLogin
    {
        private readonly CapstoneContext appDbContext;
        private readonly IConfiguration config;

        public AccountLogin(CapstoneContext appDbContext, IConfiguration config)
        {
            this.appDbContext = appDbContext;
            this.config = config;
        }

        private string GenerateToken(Account user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username!),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Role, user.AccountType!)
            };

            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"]!,
                audience: config["Jwt:Audience"]!,
                claims: userClaims,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<Account> GetUser(string username) => await appDbContext.Accounts.FirstOrDefaultAsync(e => e.Username == username);

        public async Task<LoginResponse> LoginAsync(LoginDTO model)
        {
            var findUser = await GetUser(model.Username);
            if (findUser == null) { return new LoginResponse(false, "User not found."); }

            bool isPasswordValid = BCrypt.Net.BCrypt.EnhancedVerify(model.Password, findUser.EncryptedPassword);

            if (!isPasswordValid) 
                return new LoginResponse(false, "Email/Password not valid");

            Constants.UserRole = findUser.AccountType!;

            string jwtToken = GenerateToken(findUser);
            return new LoginResponse(true, "Login successfully", jwtToken);
        }

        public string FindUserRole(string email)
        {
            Console.WriteLine($"Checking role for email: {email}"); // Log input email
            if (appDbContext.Teachers.FirstOrDefault(t => t.Email == email) != null)
            {
                Console.WriteLine("Role found: Teacher");
                return "Teacher";
            }
            else if (appDbContext.Parents.FirstOrDefault(t => t.Email == email) != null)
            {
                Console.WriteLine("Role found: Parent");
                return "Parent";
            }
            else if (appDbContext.Administrators.FirstOrDefault(t => t.Email == email) != null)
            {
                Console.WriteLine("Role found: Admin");
                return "Admin";
            }
            else
            {
                Console.WriteLine("No role found for email.");
                return ""; // No role found
            }
        }

        public async Task<RegistrationResponse> RegisterAsync(RegisterDTO model)
        {
            try
            {
                var findUser = await GetUser(model.Username);
                if (findUser != null) { return new RegistrationResponse(false, "User already exists."); }

                // DON'T THINK THIS IS EVER CALLED.
                var role = FindUserRole(model.Email);
                if (role == "") { return new RegistrationResponse(false, "User personal info not found in our database."); }
                else Constants.UserRole = role;

                if (model.Password != model.ConfirmPassword) { return new RegistrationResponse(false, "Passwords do not match."); }

                string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(model.Password, 13);

                appDbContext.Accounts.Add(
                    new Account()
                    {
                        Username = model.Username,
                        Email = model.Email,
                        AccountType = role,
                        EncryptedPassword = passwordHash
                    });

                await appDbContext.SaveChangesAsync();
                return new RegistrationResponse(true, "Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during registration: {ex}");
                return new RegistrationResponse(false, "Exception Found.");
            }
        }

		public LoginResponse RefreshToken(UserSession userSession)
		{
            CustomUserClaims customUserClaims = DecryptJWTService.DecryptToken(userSession.JWTToken);
            if (customUserClaims is null) return new LoginResponse(false, "Incorrect token");

            string newToken = GenerateToken(new Account()
            {
                Username = customUserClaims.Name,
                Email = customUserClaims.Email
            });
            return new LoginResponse(true, "New Token", newToken);
		}
	}
}
