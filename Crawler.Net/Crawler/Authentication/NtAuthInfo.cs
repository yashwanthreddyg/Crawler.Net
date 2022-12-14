namespace Crawler.Net.Crawler.Authentication;

public class NtAuthInfo : AuthInfo
{
    public String Domain { get; set; }

    public NtAuthInfo(String username, String password, String loginUrl, String domain)
        : base(AuthenticationTypeEnum.NT_AUTHENTICATION, HttpMethod.Get, loginUrl, username, password)
    {
        this.Domain = domain;
    }
}