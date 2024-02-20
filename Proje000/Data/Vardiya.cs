using System.ComponentModel.DataAnnotations;


namespace Proje000.Data
{
    public class Vardiya
    {
        [Key]
        public int VardiyaId { get; set; }
        public string? VardiyaName { get; set; }
        public DateTime Tarih { get; set; }

    }
}
