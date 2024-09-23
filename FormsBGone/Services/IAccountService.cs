using FormsBGone.DTOs;
using static FormsBGone.Responses.CustomResponses;

namespace FormsBGone.Services
{
    public interface IAccountService
    {
        Task<RegistrationResponse> RegisterAsync(RegisterDTO model);

        Task<LoginResponse> LoginAsync(LoginDTO model);
    }
}
