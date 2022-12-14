namespace Crawler.Net.Crawler.Exceptions;

public class ParseException : Exception
{
    public ParseException(string message) : base(message)
    {
    }
    
    public ParseException(Exception innerException) : base(innerException.Message, innerException)
    {
    }

    public ParseException(string message, Exception innerException) : base(message, innerException)
    {
    }
}