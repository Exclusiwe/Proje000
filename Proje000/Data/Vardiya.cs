using System.ComponentModel.DataAnnotations;


namespace Proje000.Data
{
    public class Vardiya
    {
        public Vardiya()
        {
            TakimKayit = new HashSet<TakimKayit>();
        }
        [Key]
        public int Id { get; set; }
        public string? VardiyaName { get; set; }
        public DateTime Tarih { get; set; }
        public ICollection<TakimKayit> TakimKayit { get; set; }

    }
}
