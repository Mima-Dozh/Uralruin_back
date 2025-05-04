namespace Uralruin_back.Infrastructure.FileUpload;

public class FileUploader
{
    public static async Task<string> UploadFile(IFormFile file)
    {
        FileChecker.CheckFile(file);

        var fileName = Path.GetFileName(file.FileName);

        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        var filePath = Path.Combine(uploadsFolder, fileName);

        using var fileStream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(fileStream);

        return $"/uploads/{fileName}";
    }
}
