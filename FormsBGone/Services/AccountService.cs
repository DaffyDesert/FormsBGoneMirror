using FormsBGone.Controllers;
using FormsBGone.DTOs;
using FormsBGone.Responses;
using FormsBGone.States;
using static FormsBGone.Responses.CustomResponses;

namespace FormsBGone.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient httpClient;
		private readonly IAccountController accountController;

		public AccountService(HttpClient httpClient, IAccountController accountController)
        {
            this.httpClient = httpClient;
            this.accountController = accountController;
        }

		public async Task<LoginResponse> LoginAsync(LoginDTO model)
        {
            var response = await accountController.LoginAsync(model);

            if (response == null || response.JWTToken == "") return null!;
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", response.JWTToken);

            return response;
        }

        public async Task<RegistrationResponse> RegisterAsync(RegisterDTO model)
        {
            var response = await accountController.RegisterAsync(model);
            return response;
        }
    }
}
