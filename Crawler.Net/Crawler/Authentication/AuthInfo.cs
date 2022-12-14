namespace Crawler.Net.Crawler.Authentication;

public abstract class AuthInfo
{
    public enum AuthenticationTypeEnum
    {
        BASIC_AUTHENTICATION,
        FORM_AUTHENTICATION,
        NT_AUTHENTICATION
    }

    public AuthenticationTypeEnum AuthenticationType { get; set; }
    protected HttpMethod HttpMethod { get; set; }
    protected String Protocol { get; set; }
    protected String Host { get; set; }
    protected String LoginTarget { get; set; }
    protected int Port { get; set; }
    protected String Username { get; set; }
    protected String Password { get; set; }
    
    /**
     * This constructor should only be used by extending classes
     *
     * @param authenticationType Pick the one which matches your authentication
     * @param httpMethod Choose POST / GET
     * @param loginUrl Full URL of the login page
     * @param username Username for Authentication
     * @param password Password for Authentication
     *
     * @throws MalformedURLException Make sure your URL is valid
     */
    // JAVA
    //     protected AuthInfo(AuthenticationType authenticationType, MethodType httpMethod,
    //         String loginUrl, String username, String password)
    //     throws MalformedURLException {
    //         this.authenticationType = authenticationType;
    //     this.httpMethod = httpMethod;
    //     URL url = new URL(loginUrl);
    //         this.protocol = url.getProtocol();
    //     this.host = url.getHost();
    //     this.port =
    //     url.getPort() == -1 ? url.getDefaultPort() : url.getPort();
    //     this.loginTarget = url.getFile();
    //
    //     this.username = username;
    //     this.password = password;
    // }

    // C#
    protected AuthInfo(AuthenticationTypeEnum authenticationTypeEnum, HttpMethod httpMethod,
        String loginUrl, String username, String password)
    {
        this.AuthenticationType = authenticationTypeEnum;
        this.HttpMethod = httpMethod;
        Uri url = new Uri(loginUrl);
        this.Protocol = url.Scheme;
        this.Host = url.Host;
        this.Port = url.Port;
        this.LoginTarget = url.PathAndQuery;

        this.Username = username;
        this.Password = password;
    }
}