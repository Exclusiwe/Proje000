using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Proje000.Data
{
    public class TakimKayit
    {
        [Key]
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }
        public int TakimId { get; set; }
        public Takim Takim { get; set; } 
        public int VardiyaId  { get; set; }
        public Vardiya Vardiya { get; set; } 
        public int YoneticiId { get; set; }
        public Yonetici Yonetici { get; set; } 


    }
}
