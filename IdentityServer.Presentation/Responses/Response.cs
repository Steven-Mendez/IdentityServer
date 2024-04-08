namespace IdentityServer.Presentation.Responses;

public class Response<T>(T data)
{
    public T Data { get; set; } = data;
}