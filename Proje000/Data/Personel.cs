using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proje000.Data
{
    public class Personel
    {
        public Personel()
        {
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

        public int? TakimId { get; set; }

        public Takim Takim { get; set; }

        public ICollection<TakimKayit> TakimKayit { get; set; }

    }

}
