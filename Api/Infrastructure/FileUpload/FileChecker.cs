namespace Uralruin_back.Infrastructure.FileUpload
{
    public class FileChecker
    {
        public static void CheckFile(IFormFile file)
        {
            if (!FileExists(file))
                throw new BadHttpRequestException("Empty file.");

            if (!FileSizeCorrect(file))
                throw new BadHttpRequestException("Too big file. Max size is 5Mb");

            if (!FileTypeCorrect(file))
                throw new BadHttpRequestException("Bad file type. Allowed types is: .jpg, .jpeg, .png, .gif");
        }

        private static bool FileExists(IFormFile file) => file is not null && file.Length != 0;

        private static bool FileTypeCorrect(IFormFile file)
        {
            var inspector = new FileSignatures.FileFormatInspector();
            var format = inspector.DetermineFileFormat(file.OpenReadStream());

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();

            if (format is null || !format.MediaType.StartsWith("image/"))
                return false;

            if (!file.ContentType.StartsWith("image/"))
                return false;

            if (!allowedExtensions.Contains(fileExtension))
                return false;

            return true;
        }

        private static bool FileSizeCorrect(IFormFile file)
        {
            var maxFileSize = 5 * 1024 * 1024;

            return file.Length <= maxFileSize;
        }
    }
}
