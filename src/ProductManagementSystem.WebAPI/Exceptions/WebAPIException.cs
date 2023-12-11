using System.Net;

namespace ProductManagementSystem.WebAPI.Exceptions;

public abstract class WebAPIException : Exception
{
    public HttpStatusCode StatusCode { get; }

    public WebAPIException(HttpStatusCode statusCode, string? message = null) : base(message)
    {
        StatusCode = statusCode;
    }
}
