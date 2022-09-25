

public class MovieImageEditModel
{
    [Required(ErrorMessage = "Please select the file")]
    [AllowedExtensionsValidation(new string[] { ".jfif", ".png", ".jpg", ".jpeg" })]
    public IFormFile? UploadedImageFile { get; set; }
}