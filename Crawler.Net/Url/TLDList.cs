using System.Net;
using Crawler.Net.Crawler;
using Nager.PublicSuffix;

namespace Crawler.Net.Url;

public class TLDList
{
    private bool onlineUpdate;
    private DomainParser domainParser;
    
    public TLDList(CrawlConfig config)
    {
        this.onlineUpdate = config.OnlineTldListUpdate;
        if (onlineUpdate)
        {
            Stream stream;
            String filename = config.PublicSuffixLocalFile;
            if (filename == null)
            {
                Uri uri = new Uri(config.PublicSuffixSourceUrl);
                // download the file from the uri using HttpClient
                using (var client = new HttpClient())
                {
                    stream = client.GetStreamAsync(uri).Result;
                    // save the file to temp folder and file name
                    using (var fileStream = File.Create(Path.GetTempFileName()))
                    {
                        stream.CopyTo(fileStream);
                        stream.Close();
                        stream.Dispose();
                        filename = fileStream.Name;
                    }
                }
            }
            this.domainParser = new DomainParser(new FileTldRuleProvider(filename));
        }
    }
    
    public bool Contains(string domain)
    {
        if (onlineUpdate)
        {
            // check if the domain is in the list
            var domainInfo = this.domainParser.Parse(domain);
            return domainInfo != null;
        }
        else
        {
            // verify if domain is a top private domain
            // Use Dns class
            // TODO: implement
            return true;
        }
    }

    public bool IsRegisteredDomain(string domain)
    {
        if (onlineUpdate)
        {
            var domainInfo = domainParser.Parse(domain);
            return domainInfo.RegistrableDomain != null;
        }
        else
        {
            // TODO: implement
            return true;
        }
    }
}