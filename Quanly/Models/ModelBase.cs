namespace Quanly.Models
{
    public class ModelBase
    {
        public string Importer { get; set; } = string.Empty;
        public string Updater { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
