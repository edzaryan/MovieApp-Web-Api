namespace MovieApp_Web_Api.CustomValidationAttributes
{
    public class VideoSizeConstrainsValidationAttribute : ValidationAttribute
    {
        private readonly long _maxVideoFileSize;
        private readonly long _minVideoFileSize;

        public VideoSizeConstrainsValidationAttribute(long minFileSize, long maxFileSize)
        {
            _minVideoFileSize = minFileSize;
            _maxVideoFileSize = maxFileSize;
        }
        

        public override bool IsValid(object? value)
        {
            if (value is IFormFile model)
            {
                if (model.Length < _minVideoFileSize || model.Length > _maxVideoFileSize)
                {
                    ErrorMessage = $"The File's Size Must Be In Between {_minVideoFileSize} And {_maxVideoFileSize}";

                    return false;
                }

                return true;
            }

            ErrorMessage = $"Enter valid file";

            return false;
        }

    }
}
