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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Personel - Takim ilişkisi (One-to-Many)
            modelBuilder.Entity<Takim>()
                .HasMany(t => t.personels)
                .WithOne(p => p.Takim)
                .HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            // Yonetici - Takim ilişkisi (One-to-Many)
            modelBuilder.Entity<Yonetici>()
               .HasMany(y => y.takims)
               .WithOne(t => t.Yonetici)
               .HasForeignKey(y => y.Id)
               .OnDelete(DeleteBehavior.Restrict);
            // TakimKayit - Personel ilişkisi
            modelBuilder.Entity<TakimKayit>()
                .HasOne(tk => tk.Personel)
                .WithMany()
                .HasForeignKey(tk => tk.PersonelId)
                .OnDelete(DeleteBehavior.Restrict);

            // TakimKayit - Takim ilişkisi
            modelBuilder.Entity<TakimKayit>()
                .HasOne(tk => tk.Takim)
                .WithMany()
                .HasForeignKey(tk => tk.TakimId)
                .OnDelete(DeleteBehavior.Restrict);

            // TakimKayit - Vardiya ilişkisi
            modelBuilder.Entity<TakimKayit>()
                .HasOne(tk => tk.Vardiya)
                .WithMany()
                .HasForeignKey(tk => tk.VardiyaId)
                .OnDelete(DeleteBehavior.Restrict);

            // TakimKayit - Yonetici ilişkisi
            modelBuilder.Entity<TakimKayit>()
                .HasOne(tk => tk.Yonetici)
                .WithMany()
                .HasForeignKey(tk => tk.YoneticiId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
