using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using ProductManagementSystem.WebAPI.Exceptions;

namespace ProductManagementSystem.WebAPI.Services;

public partial class FileUploadService : IFileUploadService
{
    public async Task<string> UploadFileAsync(HttpRequest request)
    {
        if (!request.HasFormContentType ||
                !MediaTypeHeaderValue.TryParse(request.ContentType, out var mediaTypeHeader) ||
                string.IsNullOrEmpty(mediaTypeHeader.Boundary.Value))
        {
            throw new UnsupportedMediaTypeException();
        }

        string boundary = HeaderUtilities.RemoveQuotes(mediaTypeHeader.Boundary.Value).Value 
            ?? throw new UnsupportedMediaTypeException();

        MultipartReader reader = new(boundary, request.Body);
        MultipartSection? section = await reader.ReadNextSectionAsync();

        while (section is not null)
        {
            bool hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition,
                out ContentDispositionHeaderValue? contentDisposition);

            if (hasContentDispositionHeader && contentDisposition!.DispositionType.Equals("form-data") &&
                !string.IsNullOrEmpty(contentDisposition.FileName.Value))
            {
                // TODO: Verify upload
                string fileName = Path.GetRandomFileName();
                string saveToPath = Path.Combine(Path.GetTempPath(), fileName);

                using (FileStream targetStream = File.Create(saveToPath))
                {
                    await section.Body.CopyToAsync(targetStream);
                }

                return saveToPath;
            }

            section = await reader.ReadNextSectionAsync();
        }

        throw new EmptyFileException();
    }
}
