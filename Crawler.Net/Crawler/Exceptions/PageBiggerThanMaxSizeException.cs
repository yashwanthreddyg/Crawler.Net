namespace Crawler.Net.Crawler.Exceptions;

public class PageBiggerThanMaxSizeException : Exception
{
    public PageBiggerThanMaxSizeException(string message) : base(message)
    {
    }
}