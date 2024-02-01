using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        { 

        }
       public DbSet<Haberler> haberlers { get; set; }
        public DbSet<Reklam> Reklamlars  { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }
        public DbSet<Kulanıcılar> Kulanıcılars { get; set; }
        public DbSet<Yazarlar> Yazarlars { get; set; }
        public DbSet<Yetkiler> Yetkilers  { get; set; }
        public DbSet<Katagori> katagoris { get; set; }
        public DbSet<Gazete> Gazetes { get; set; }
        public DbSet<Konumlar> Konumlars { get; set; }
        public DbSet<Resimler> Resimlers { get; set; }

}

    }
