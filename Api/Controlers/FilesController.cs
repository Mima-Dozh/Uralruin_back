using Microsoft.AspNetCore.Mvc;
using Uralruin_back.Infrastructure.FileUpload;

namespace Uralruin_back.Controlers;

[ApiController]
[Route("/api/v1/files")]
public class FilesController : ControllerBase
{

    [HttpPost("upload")]
    public async Task<ActionResult> UploadFile(IFormFile file)
    {
        var filePath = await FileUploader.UploadFile(file);
        return CreatedAtAction(nameof(UploadFile), new { filePath });
    }
}
