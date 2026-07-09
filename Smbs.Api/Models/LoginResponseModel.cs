namespace Smbs.Api.Models
{
    public class LoginResponseModel
    {
        public string AccessToken { get; set; }
        public string UserName { get; set; }
        public string RefreshToken { get; set; }
        public int ExpireIn { get; set; }
    }
}
