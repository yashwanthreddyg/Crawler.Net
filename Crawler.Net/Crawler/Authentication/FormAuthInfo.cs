namespace Crawler.Net.Crawler.Authentication;

public class FormAuthInfo : AuthInfo
{
    public String UsernameFromStr { get; set; }
    public String PasswordFromStr { get; set; }

    public FormAuthInfo(String username, String password, String loginUrl, String usernameFormStr,
        String passwordFormStr) : base(AuthenticationTypeEnum.FORM_AUTHENTICATION, HttpMethod.Post, loginUrl, username,
        password)
    {
        this.UsernameFromStr = usernameFormStr;
        this.PasswordFromStr = passwordFormStr;
    }
}