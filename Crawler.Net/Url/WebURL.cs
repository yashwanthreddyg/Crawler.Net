using System.Runtime.Serialization;

namespace Crawler.Net.Url;

public class WebURL : ISerializable
{
    private static readonly long serialVersionUID = 1L;

    // TODO: primary key annotation
    private string _url;
    
    public int ParentDocid { get; set; }
    public String ParentUrl { get; set; }
    public short Depth { get; set; }
    public String RegisteredDomain { get; set; }
    public String SubDomain { get; set; }
    public String Path { get; set; }
    public String Anchor { get; set; }
    public byte Priority { get; set; }
    public String Tag { get; set; }
    public IDictionary<String, String> attributes { get; set; }
    public TLDList tldList;
    public string Url
    {
        get { return _url; }
        set
        {
            this._url = value;
            int domainStartIdx = value.IndexOf("//", StringComparison.Ordinal) + 2;
            int domainEndIdx = value.IndexOf('/', domainStartIdx);
            domainEndIdx = (domainEndIdx > domainStartIdx) ? domainEndIdx : _url.Length;
            // get domain using substring
            string domain = value.Substring(domainStartIdx, domainEndIdx - domainStartIdx);
            SubDomain = "";
            if (tldList != null && !string.IsNullOrEmpty(domain) && Util.Util.IsValidDomainName(domain)) {
                String candidate = null;
                String rd = null;
                String sd = null;
                String[] parts = domain.Split("\\.");
                for (int i = parts.Length - 1; i >= 0; i--) {
                    if (rd == null) {
                        if (candidate == null) {
                            candidate = parts[i];
                        } else {
                            candidate = parts[i] + "." + candidate;
                        }
                        if (tldList.IsRegisteredDomain(candidate)) {
                            rd = candidate;
                        }
                    } else {
                        if (sd == null) {
                            sd = parts[i];
                        } else {
                            sd = parts[i] + "." + sd;
                        }
                    }
                }
                if (rd != null) {
                    RegisteredDomain = rd;
                }
                if (sd != null) {
                    SubDomain = sd;
                }
            }
            Path = _url.Substring(domainEndIdx);
            int pathEndIdx = Path.IndexOf('?');
            if (pathEndIdx >= 0) {
                Path = Path.Substring(0, pathEndIdx);
            }
        }

    }
    // override equals
    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        if (obj == this)
            return true;
        if (obj.GetType() != this.GetType())
            return false;
        WebURL other = (WebURL) obj;
        return Url !=null && _url.Equals(other.Url);
    }
    
    // implement GetObjectData
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Url", Url);
        info.AddValue("ParentDocid", ParentDocid);
        info.AddValue("ParentUrl", ParentUrl);
        info.AddValue("Depth", Depth);
        info.AddValue("RegisteredDomain", RegisteredDomain);
        info.AddValue("SubDomain", SubDomain);
        info.AddValue("Path", Path);
        info.AddValue("Anchor", Anchor);
        info.AddValue("Priority", Priority);
        info.AddValue("Tag", Tag);
        info.AddValue("attributes", attributes);
    }
}