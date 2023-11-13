namespace Isbn.Web.Api.Exceptions;

public class IsbnException : Exception
{
    public IsbnException(string message) 
        : base(message){}
    
    public IsbnException(string message, Exception e) 
        : base(message, e){}
}