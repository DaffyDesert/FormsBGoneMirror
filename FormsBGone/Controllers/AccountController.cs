using FormsBGone.DTOs;
using FormsBGone.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static FormsBGone.Responses.CustomResponses;

namespace FormsBGone.Controllers
{
    public class AccountController : IAccountController
    {
        private readonly IAccountLogin accountRepo;

        public AccountController(IAccountLogin accountRepo)
        {
            this.accountRepo = accountRepo;
        }

        public async Task<RegistrationResponse> RegisterAsync(RegisterDTO model)
        {
            return await accountRepo.RegisterAsync(model);
        }

        public async Task<LoginResponse> LoginAsync(LoginDTO model)
        {
            var result = await accountRepo.LoginAsync(model);
            return result;
        }

        [AllowAnonymous]
        public LoginResponse RefreshToken(UserSession model)
        {
            var result = accountRepo.RefreshToken(model);
            return result;
        }
    }
}
