using System.Net;

namespace ProductManagementSystem.WebAPI.Exceptions;

public class UnsupportedMediaTypeException : WebAPIException
{
    public UnsupportedMediaTypeException() : base(HttpStatusCode.UnsupportedMediaType) { }
}