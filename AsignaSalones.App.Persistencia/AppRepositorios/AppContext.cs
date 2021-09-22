using Microsoft.EntityFrameworkCore;
using AsignaSalones.App.Dominio;

namespace AsignaSalones.App.Persistencia
{
    public class AppContext:DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Directivo> Directivos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<PersonalAseo> PersonasAseo { get; set; }
        public DbSet<Contagiado> Contagiados { get; set; }
        public DbSet<SedeUniversidad> SedesUniversidad { get; set; }
        public DbSet<Salon> Salones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source = (Localdb)\\MSSQLLocalDB; Initial Catalog = AsignaSalones");
            }
        }
    }
    
}