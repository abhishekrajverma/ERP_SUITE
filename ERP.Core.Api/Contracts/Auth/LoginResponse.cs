namespace ERP.Core.Api.Contracts.Auth
{
    public class LoginResponse
    {
        public string? Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
