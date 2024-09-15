namespace MVCDay6.Helper
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            //Get located folder path
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", folderName);

            //Get file name and make ir unique
            var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";

            //Get file path
            var filePath = Path.Combine(folderPath, fileName);

            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);
            return fileName;
        }
    }
}
