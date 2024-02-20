using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Proje000.Data
{
    public class TakimKayit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TakimKayitId { get; set; }
        public int PersonelId { get; set; }
        public Personel Personel { get; set; } = null!;
        public int Id { get; set; }
        public Takim Takim { get; set; } =null!;
        public int VardiyaId  { get; set; }
        public Vardiya Vardiya { get; set; } = null!;

    }
}
