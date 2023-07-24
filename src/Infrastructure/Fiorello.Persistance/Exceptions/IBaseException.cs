using System.Net;
namespace Fiorello.Persistance.Exceptions;

public interface IExceptionHandlerFeature
{
     public int StatusCode { get; set; }
     public string CustomMessage { get; set; }
}
