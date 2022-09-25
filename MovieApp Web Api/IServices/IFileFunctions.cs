
public interface IFileFunctions
{
    string UpdateFile(IFormFile file, string? imageName, string folderName);

    string UploadVideoFile(IFormFile videoFile, string folderName);

    void DeleteFile(string? fileName, string folderName);

    int GetVideoFileDurationInMinutes(string filePath, string folderName);
}