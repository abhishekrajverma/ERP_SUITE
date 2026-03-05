using ERP.Core.Api.Contracts.Auth;

namespace ERP.Core.Api.Services
{
    public interface IAuthService
    {
        LoginResponse Login(LoginRequest request);
    }
}