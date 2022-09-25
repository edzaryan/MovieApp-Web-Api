using WMPLib;

public class CustomFileFunctions : IFileFunctions
{
    private readonly IWebHostEnvironment webHostEnvironment;

    public CustomFileFunctions(IWebHostEnvironment webHostEnvironment) => this.webHostEnvironment = webHostEnvironment;


    public string UpdateFile(IFormFile? file, string? fileName, string folderName)
    {
        if (file == null) throw new Exception("The file is not found");

        string uploadsFolderName = $"{webHostEnvironment.WebRootPath}\\{folderName}\\";

        string uniqueFileName = fileName ?? UniqueStringGenerator(10) + Path.GetExtension(file.FileName);

        string fileFullPath = uploadsFolderName + uniqueFileName;

        using (var fileStream = new FileStream(fileFullPath, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }

        return uniqueFileName;
    }


    public string UploadVideoFile(IFormFile videoFile, string folderName)
    {
        string uploadsFolderName = $"{webHostEnvironment.WebRootPath}\\{folderName}\\";

        string uniqueFileFullName = UniqueStringGenerator(10) + Path.GetExtension(videoFile.FileName);

        string fileFullPath = uploadsFolderName + uniqueFileFullName;

        using (FileStream fs = System.IO.File.Create(fileFullPath))
        {
            videoFile.CopyTo(fs);
            fs.Flush();
        }

        return uniqueFileFullName;
    }


    public void DeleteFile(string? fileName, string folderName)
    {
        if (fileName == null) return;

        string filePath = $"{webHostEnvironment.WebRootPath}\\{folderName}\\{fileName}";

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }


    public string UniqueStringGenerator(int length)
    {
        Random random = new Random();

        string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        string uniqueString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());

        return uniqueString;
    }


    public int GetVideoFileDurationInMinutes(string filePath, string folderName)
    {
        var player = new WindowsMediaPlayer();

        string fileFullPath = $"{webHostEnvironment.WebRootPath}\\{folderName}\\{filePath}";

        var clip = player.newMedia(fileFullPath);

        return (int)TimeSpan.FromMinutes(clip.duration).TotalMinutes / 60;
    }
}