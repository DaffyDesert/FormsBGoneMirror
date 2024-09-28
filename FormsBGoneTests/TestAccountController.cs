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

namespace FormsBGoneTests
{
	[TestClass]
	public class TestAccountController
	{
		private static WebApplicationBuilder builder = WebApplication.CreateBuilder();
		private static CapstoneContext context = new CapstoneContext(builder.Configuration.GetConnectionString("DefaultConnection")!);
		private static IAccountLogin repo = new AccountLogin(context, builder.Configuration);
		private static AccountController controller = new(repo);

		[TestMethod]
		public async Task TestLogin()
		{
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

			ObjectResult result1 = (ObjectResult)((await controller.LoginAsync(login1)).Result!);
			ObjectResult result2 = (ObjectResult)((await controller.LoginAsync(login2)).Result!);
			ObjectResult result3 = (ObjectResult)((await controller.LoginAsync(login3)).Result!);

			var value1 = ((LoginResponse)(result1.Value!));
			var value2 = ((LoginResponse)(result2.Value!));
			var value3 = ((LoginResponse)(result3.Value!));

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
				ObjectResult result1 = (ObjectResult)((await controller.RegisterAsync(register1)).Result!);
				var value1 = ((RegistrationResponse)(result1.Value!));

				Assert.AreEqual(value1.Flag, false);
				Assert.AreEqual(value1.Message, "User personal info not found in our database.");

				context.Add(newParent);
				context.SaveChanges();

				result1 = (ObjectResult)((await controller.RegisterAsync(register1)).Result!);
				var result2 = (ObjectResult)((await controller.RegisterAsync(register2)).Result!);
				var result3 = (ObjectResult)((await controller.RegisterAsync(register3)).Result!);

				value1 = ((RegistrationResponse)(result1.Value!));
				var value2 = ((RegistrationResponse)(result2.Value!));
				var value3 = ((RegistrationResponse)(result3.Value!));

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