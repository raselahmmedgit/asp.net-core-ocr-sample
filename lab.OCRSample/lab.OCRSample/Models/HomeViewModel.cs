namespace lab.OCRSample.Models
{
    public class HomeViewModel
    {
        public string Id { get; set; }
        public string SubFolderName { get; set; }
        public List<IFormFile> EmguCVOCRFiles { get; set; }
        public List<IFormFile> GoogleVisionOCRFiles { get; set; }
    }
}
