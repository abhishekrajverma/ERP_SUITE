namespace ERP.Core.Api.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
