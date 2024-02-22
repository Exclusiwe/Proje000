using Microsoft.EntityFrameworkCore;

namespace Proje000.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Personel> personels => Set<Personel>();
        public DbSet<Yonetici> yoneticis => Set<Yonetici>();
        public DbSet<Takim> takims => Set<Takim>();
        public DbSet<Vardiya> vardiyas => Set<Vardiya>();
        public DbSet<TakimKayit> takimkayits => Set<TakimKayit>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=B24000199\\SQLEXPRESS;Initial Catalog=ContextDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            }
        }
        
    }
}
