using System.Net;
using System.Net.Http.Headers;

namespace Crawler.Net.Crawler;

public class CrawlConfig
{
    /**
     * The lock timeout for the underlying sleepycat DB, in milliseconds
     */
    private long DbLockTimeout = 500;

    /**
     * Maximum depth of crawling For unlimited depth this parameter should be
     * set to -1
     */
    private int MaxDepthOfCrawling = -1;

    /**
     * Maximum number of pages to fetch For unlimited number of pages, this
     * parameter should be set to -1
     */
    private int MaxPagesToFetch = -1;

    /**
     * user-agent string that is used for representing your crawler to web
     * servers. See http://en.wikipedia.org/wiki/User_agent for more details
     */
    private String UserAgentString = "Crawler.Net (https://github.com/yashwanthreddyg/Crawler.Net/)";

    /**
     * Default request header values.
     */
    private Dictionary<string, string> DefaultHeaders = new Dictionary<string, string>();
    
    
    /**
     * Politeness delay in milliseconds (delay between sending two requests to
     * the same host).
     */
    private int PolitenessDelay = 200;

    /**
     * Should we also crawl https pages?
     */
    private bool IncludeHttpsPages = true;

    /**
     * Should we fetch binary content such as images, audio, ...?
     */
    private bool IncludeBinaryContentInCrawling = false;

    /**
     * Should we process binary content such as image, audio, ... using TIKA?
     */
    private bool ProcessBinaryContentInCrawling = false;

    /**
     * Maximum Connections per host
     */
    private int MaxConnectionsPerHost = 100;

    /**
     * Maximum total connections
     */
    private int MaxTotalConnections = 100;

    /**
     * Socket timeout in milliseconds
     */
    private int SocketTimeout = 20000;

    /**
     * Connection timeout in milliseconds
     */
    private int ConnectionTimeout = 30000;

    /**
     * Max number of outgoing links which are processed from a page
     */
    private int MaxOutgoingLinksToFollow = 5000;

    /**
     * Max allowed size of a page. Pages larger than this size will not be
     * fetched.
     */
    private int MaxDownloadSize = 1048576;

    /**
     * Should we follow redirects?
     */
    private bool FollowRedirects = true;

    /**
     * Should the TLD list be updated automatically on each run? Alternatively,
     * it can be loaded from the embedded tld-names.zip file that was obtained from
     * https://publicsuffix.org/list/public_suffix_list.dat
     */
    private bool _OnlineTldListUpdate = false;
    public bool OnlineTldListUpdate
    {
        get { return _OnlineTldListUpdate; }
        set
        {
            _OnlineTldListUpdate = value;
        }
    }

    private String _PublicSuffixSourceUrl = "https://publicsuffix.org/list/public_suffix_list.dat";

    public String PublicSuffixSourceUrl
    {
        get { return _PublicSuffixSourceUrl; }
        set { _PublicSuffixSourceUrl = value; }
    }
    
    private String _PublicSuffixLocalFile = null;
    public String PublicSuffixLocalFile
    {
        get
        { 
         return _PublicSuffixLocalFile;
        }
        set
        {
            _PublicSuffixLocalFile = value;
        }
    }

    /**
     * Should the crawler stop running when the queue is empty?
     */
    private bool ShutdownOnEmptyQueue = true;

    /**
     * Wait this long before checking the status of the worker threads.
     */
    private int ThreadMonitoringDelaySeconds = 10;

    /**
     * Wait this long to verify the craweler threads are finished working.
     */
    private int ThreadShutdownDelaySeconds = 10;

    /**
     * Wait this long in seconds before launching cleanup.
     */
    private int CleanupDelaySeconds = 10;

    /**
     * If crawler should run behind a proxy, this parameter can be used for
     * specifying the proxy host.
     */
    private String ProxyHost = null;

    /**
     * If crawler should run behind a proxy, this parameter can be used for
     * specifying the proxy port.
     */
    private int ProxyPort = 80;

    /**
     * If crawler should run behind a proxy and user/pass is needed for
     * authentication in proxy, this parameter can be used for specifying the
     * username.
     */
    private String ProxyUsername = null;

    /**
     * If crawler should run behind a proxy and user/pass is needed for
     * authentication in proxy, this parameter can be used for specifying the
     * password.
     */
    private String ProxyPassword = null;

}