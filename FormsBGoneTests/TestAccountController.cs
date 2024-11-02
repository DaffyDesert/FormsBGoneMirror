using FormsBGone;
using FormsBGone.Model;
using FormsBGone.Controllers;
using FormsBGone.DTOs;
using FormsBGone.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using static FormsBGone.Responses.CustomResponses;
using Microsoft.Extensions.DependencyInjection;

namespace FormsBGoneTests
{
	[TestClass]
	public class TestAccountController
	{
		private static WebApplicationBuilder builder;
		private static CapstoneContext context;
		private static AccountController controller;

		private static void SetUp()
		{
			builder = WebApplication.CreateBuilder();
			builder.Services.AddDbContext<CapstoneContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});
			context = builder.Build().Services.GetService<CapstoneContext>();
			IAccountLogin repo = new AccountLogin(context, builder.Configuration);
			controller = new(repo);
		}

		[TestMethod]
		public async Task TestLogin()
		{
			SetUp();
			LoginDTO login1 = new()
			{
				Username = "ThisIsNotARealUsername",
				Password = "Bazinga"
			};
			LoginDTO login2 = new()
			{
				Username = "tester",
				Password = "plsworl"
			};
			LoginDTO login3 = new()
			{
				Username = "tester",
				Password = "plswork"
			};

			var value1 = await controller.LoginAsync(login1);
			var value2 = await controller.LoginAsync(login2);
			var value3 = await controller.LoginAsync(login3);

			Assert.AreEqual(value1.Flag, false);
			Assert.AreEqual(value1.Message, "User not found.");
			Assert.AreEqual(value2.Flag, false);
			Assert.AreEqual(value2.Message, "Email/Password not valid");
			Assert.AreEqual(value3.Flag, true);
			Assert.AreEqual(value3.Message, "Login successfully");
			Assert.IsNotNull(value3.JWTToken);
			Assert.AreNotEqual(value3.JWTToken, "");
		}

		[TestMethod]
		public async Task TestRegister()
		{
			SetUp();
			Parent newParent = new()
			{
				Email = "TestRegister@TestAccountController.cs",
				FirstName = "TestRegister",
				MiddleInitial = "x",
				LastName = "TestAccountController"
			};
			RegisterDTO register1 = new()
			{
				Username = "TestRegister",
				Email = "TestRegister@TestAccountController.cs",
				Password = "Test",
				ConfirmPassword = "Tesp"
			};
			RegisterDTO register2 = new()
			{
				Username = "TestRegister",
				Email = "TestRegister@TestAccountController.cs",
				Password = "Test",
				ConfirmPassword = "Test"
			};
			RegisterDTO register3 = new()
			{
				Username = "admin3",
				Email = "admin3@example.com",
				Password = "password",
				ConfirmPassword = "password"
			};

			try
			{
				var value1 = await controller.RegisterAsync(register1);

				Assert.AreEqual(value1.Flag, false);
				Assert.AreEqual(value1.Message, "User personal info not found in our database.");

				context.Add(newParent);
				context.SaveChanges();

				value1 = await controller.RegisterAsync(register1);
				var value2 = await controller.RegisterAsync(register2);
				var value3 = await controller.RegisterAsync(register3);

				Assert.AreEqual(value1.Flag, false);
				Assert.AreEqual(value1.Message, "Passwords do not match.");
				Assert.AreEqual(value2.Flag, true);
				Assert.AreEqual(value2.Message, "Success");
				Assert.AreEqual(value3.Flag, false);
				Assert.AreEqual(value3.Message, "User already exists.");

			}
			catch { }
			finally
			{
				context.Database.ExecuteSql($"delete from Account where Email = {newParent.Email}");
				context.Database.ExecuteSql($"delete from Parent where Email = {newParent.Email}");
				context.SaveChanges();
			}
		}
	}
}