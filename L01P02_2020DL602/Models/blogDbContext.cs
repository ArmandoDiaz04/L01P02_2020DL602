using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace L01P02_2020DL602.Models
{
    public class blogDbContext : DbContext
    {
        public blogDbContext(DbContextOptions options) : base(options) { }

        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<publicaciones> publiciaciones { get; set; }
        public DbSet<calificaciones> calificaciones { get; set; }
        public DbSet<comentarios> comentarios { get; set; }

    }
}
