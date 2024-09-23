using FormsBGone.DTOs;
using static FormsBGone.Responses.CustomResponses;

namespace FormsBGone.Repos
{
    public interface IAccountLogin
    {
        Task<RegistrationResponse> RegisterAsync(RegisterDTO model);

        Task<LoginResponse> LoginAsync(LoginDTO model);

        LoginResponse RefreshToken(UserSession userSession);
    }
}
