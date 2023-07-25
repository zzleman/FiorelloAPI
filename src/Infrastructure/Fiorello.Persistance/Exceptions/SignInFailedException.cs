using System.Net;

namespace Fiorello.Persistance.Exceptions;

public class SignInFailedException : Exception, IBaseException
{
    public int StatusCode { get; set; }
    public string CustomMessage { get; set; }

    public SignInFailedException(string message) : base(message)
    {
        StatusCode=(int)HttpStatusCode.BadRequest;
        CustomMessage=message;
    }
}
