using System.Net;

namespace ProductManagementSystem.WebAPI.Exceptions;

public class EmptyFileException : WebAPIException
{
    public EmptyFileException() : base(HttpStatusCode.BadRequest) { }
}
