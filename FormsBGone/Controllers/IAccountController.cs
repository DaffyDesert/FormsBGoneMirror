using FormsBGone.DTOs;
using Microsoft.AspNetCore.Mvc;
using static FormsBGone.Responses.CustomResponses;

namespace FormsBGone.Controllers
{
	public interface IAccountController
	{
		public Task<RegistrationResponse> RegisterAsync(RegisterDTO model);
		public Task<LoginResponse> LoginAsync(LoginDTO model);
		public LoginResponse RefreshToken(UserSession model);
	}
}
