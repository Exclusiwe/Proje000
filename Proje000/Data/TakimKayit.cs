using System.ComponentModel.DataAnnotations;
namespace Proje000.Data
{
    public class TakimKayit
    {
        public int TakimKayitId { get; set; }
        public int PersonelId { get; set; }
        public int TakimId { get; set; }
        public int VardiyaId  { get; set; }

    }
}
