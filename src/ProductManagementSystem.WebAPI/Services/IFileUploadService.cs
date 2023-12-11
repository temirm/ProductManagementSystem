namespace ProductManagementSystem.WebAPI.Services;

public interface IFileUploadService
{
    /// <summary>
    /// Uploads file from the request and returns file name.
    /// </summary>
    /// <param name="request"></param>
    /// <returns>File name</returns>
    Task<string> UploadFileAsync(HttpRequest request);
}
