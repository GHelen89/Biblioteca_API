using Biblioteca_API.Authentication;

namespace Biblioteca_API.Services.USerService
{
    public interface IUserService
    {
        AuthenticationResponse Authenticate(AuthenticateRequest model);
    }
}
