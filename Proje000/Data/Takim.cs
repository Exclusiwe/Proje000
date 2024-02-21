using System.ComponentModel.DataAnnotations;

namespace Proje000.Data
{
    public class Takim
    {
        public Takim()
        {
            personels = new HashSet<Personel>();
            TakimKayit = new HashSet<TakimKayit>();
         

        }
        [Key]
        public int Id { get; set; }

        public string TakimAdi { get; set; }
        public ICollection<TakimKayit> TakimKayit { get; set; }
        public ICollection<Personel> personels { get; set; }
        public int? YoneticiId { get; set; }
        public Yonetici Yonetici { get; set; }


    }
}
