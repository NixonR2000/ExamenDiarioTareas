using ExamenDiarioTareas.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenDiarioTareas.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarea> Tarea { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().ToTable("usuario");

            modelBuilder.Entity<Usuario>().Property(u => u.Nombre).HasColumnName("nombre");
            modelBuilder.Entity<Usuario>().Property(u => u.Correo).HasColumnName("correo");
            modelBuilder.Entity<Usuario>().Property(u => u.Contrasena).HasColumnName("contrasena");
            modelBuilder.Entity<Usuario>().Property(u => u.CreatedAt).HasColumnName("created_at");

            modelBuilder.Entity<Tarea>().ToTable("Tarea");

            modelBuilder.Entity<Tarea>().Property(t => t.Descripcion).HasColumnName("descripcion");
        }
    
}
}
