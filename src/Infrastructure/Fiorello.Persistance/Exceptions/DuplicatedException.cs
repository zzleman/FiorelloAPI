using System.Net;

namespace Fiorello.Persistance.Exceptions;

public class DuplicatedException : Exception, IBaseException
{
    public int StatusCode { get; set;}

    public string CustomMessage { get; set; } = null!;
    public DuplicatedException(string message):base(message)
    {
        StatusCode=(int)HttpStatusCode.Conflict;
        CustomMessage=message;
    }
}
