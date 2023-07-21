namespace Fiorello.Persistance.Exceptions;

public interface IBaseException
{
    int StatusCode { get; }
    string Message { get; }
}
