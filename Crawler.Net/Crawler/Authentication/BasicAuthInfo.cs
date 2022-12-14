namespace Crawler.Net.Crawler.Authentication;

public class BasicAuthInfo : AuthInfo
{
    /**
     * Constructor
     *
     * @param username Username used for Authentication
     * @param password Password used for Authentication
     * @param loginUrl Full Login URL beginning with "http..." till the end of the url
     *
     * @throws MalformedURLException Make sure your URL is valid
     */
    public BasicAuthInfo(String username, String password, String loginUrl) : base(
        AuthenticationTypeEnum.BASIC_AUTHENTICATION, HttpMethod.Get, loginUrl, username,
        password) {}
}