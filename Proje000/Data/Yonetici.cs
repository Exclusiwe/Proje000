using System.ComponentModel.DataAnnotations;


namespace Proje000.Data
{
    public class Yonetici
    {
        public Yonetici()
        {
            takims = new HashSet<Takim>();
            TakimKayit = new HashSet<TakimKayit>();

        }
        [Key]
        public int Id { get; set; }
        public string? Adi { get; set; }
        public string? Soyadi { get; set; }
        public string? KullaniciAdi { get; set; }
        public string? Mail { get; set; }
        public string? TelefonNo { get; set; }
        public string? Adres { get; set; }
        public string? Unvan { get; set; }
        public bool Aktif { get; set; }
        public ICollection<Takim> takims { get; set; }
        public ICollection<TakimKayit> TakimKayit { get; set; }


    }
}
