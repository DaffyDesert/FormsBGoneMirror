using FormsBGone.DTOs;
using FormsBGone.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static FormsBGone.Responses.CustomResponses;

namespace FormsBGone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountLogin accountRepo;

        public AccountController(IAccountLogin accountRepo)
        {
            this.accountRepo = accountRepo;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegisterDTO model)
        {
            var result = await accountRepo.RegisterAsync(model);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LoginAsync(LoginDTO model)
        {
            var result = await accountRepo.LoginAsync(model);
            return Ok(result);
        }

        [HttpPost("refresh-token")]
        [AllowAnonymous]
        public ActionResult<LoginResponse> RefreshToken(UserSession model)
        {
            var result = accountRepo.RefreshToken(model);
            return Ok(result);
        }
    }
}
