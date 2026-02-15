using ERP.Core.Api.Models;

namespace ERP.Core.Api.Services
{
    public interface IAuthService
    {
        LoginResponse Login(LoginRequest request);
    }
}