namespace IdentityServer.Presentation.Responses;

/// <summary>
/// Represents a generic response container for data being returned by the API.
/// </summary>
/// <typeparam name="T">The type of the data contained in the response.</typeparam>
/// <param name="data">The data to be contained in the response.</param>
public class Response<T>(T data)
{
    /// <summary>
    /// Gets or sets the data contained in the response.
    /// </summary>
    public T Data { get; set; } = data;
}