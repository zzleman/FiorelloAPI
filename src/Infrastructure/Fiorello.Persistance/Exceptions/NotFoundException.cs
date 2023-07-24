using System.Net;

namespace Fiorello.Persistance.Exceptions;

public class NotFoundException : Exception, IBaseException
{
    public int StatusCode { get ; set; }
    public string CustomMessage { get; set ; }
    public NotFoundException(string message):base(message)
    {
        StatusCode=(int)HttpStatusCode.NotFound;
        CustomMessage=message;
    }
}
