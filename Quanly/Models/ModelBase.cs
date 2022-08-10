namespace Quanly.Models
{
    public class ModelBase
    {
        public string? Importer { get; set; } = "Ad";
        public string? Note { get; set; } = string.Empty;
        public DateTime? DateAdded { get; set; } = DateTime.Now;
    }
}