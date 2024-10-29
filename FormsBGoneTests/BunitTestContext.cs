using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bunit;
using FormsBGone.Repos;
using FormsBGone.Services;
using FormsBGone;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using FormsBGone.States;
using FormsBGone.Components;
using Microsoft.Extensions.Hosting;
using FormsBGone.Controllers;

public abstract class BunitTestContext : TestContextWrapper
{
    [TestInitialize]
    public void Setup() => TestContext = new Bunit.TestContext();

    [TestCleanup]
    public void TearDown() => TestContext?.Dispose();

	public void SetUpServices()
	{
		var config = WebApplication.CreateBuilder().Configuration;
		var env = WebApplication.CreateBuilder().Environment;
		Services.AddRazorComponents().AddInteractiveServerComponents();
		Services.AddControllers();

		Services.AddDbContext<CapstoneContext>(options =>
		{
			options.UseSqlServer("Server=tcp:capstonebgone.database.windows.net,1433;Initial Catalog=capstone;Persist Security Info=False;User ID=principal;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
		});

		Services.AddAuthentication(options =>
		{
			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		}).AddJwtBearer(options =>
		{
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateIssuerSigningKey = true,
				ValidateLifetime = true,
				ValidIssuer = config["Jwt:Issuer"],
				ValidAudience = config["Jwt:Audience"],
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!))
			};
		});
		Services.AddScoped<IAccountLogin, AccountLogin>();
		Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(config["Jwt:Issuer"]!) });
		Services.AddScoped<IAccountController, AccountController>();
		Services.AddScoped<IAccountService, AccountService>();
		Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

		Services.AddSingleton<IConfiguration>(config);
		Services.AddSingleton<IWebHostEnvironment>(env);
	}
}