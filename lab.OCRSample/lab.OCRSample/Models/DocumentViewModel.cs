namespace lab.OCRSample.Models
{
    public class DocumentViewModel
    {
        public string Id { get; set; }
        public string MimeType { get; set; }
        public decimal? FileSizeMb { get; set; }
        public string SourcePath { get; set; }
        public byte[] SourceFile { get; set; }
        public string FileName { get; set; }
    }
}
