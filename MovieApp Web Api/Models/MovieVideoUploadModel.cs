

public class MovieVideoUploadModel
{
    [Required(ErrorMessage = "Please select the file")]
    [VideoSizeConstrainsValidation((long)200 * 1024 * 1024, (long)4 * 1024 * 1024 * 1024)]
    [AllowedExtensionsValidation(new string[] { ".mp4" })]
    public IFormFile? UploadedVideoFile { get; set; }
}