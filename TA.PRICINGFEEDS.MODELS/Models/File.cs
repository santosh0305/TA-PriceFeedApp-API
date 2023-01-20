using Microsoft.AspNetCore.Http;

namespace TA.PRICINGFEEDS.ENTITIES.Models
{
    public enum FileType
    {
        DOCX = 1
    }

    public class FileDetails
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public FileType FileType { get; set; }
    }

    public class FileUploadModel
    {
        public IFormFile FileDetails { get; set; }
        public FileType FileType { get; set; }
    }

    public class FileRows
    {
        public int StoreId { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
