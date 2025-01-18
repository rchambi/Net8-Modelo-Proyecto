using Microsoft.EntityFrameworkCore;
using proyectModelo.Modelos;

namespace proyectModelo.Repositories
{
    // RegistroPersonas.Data/ApplicationDbContext.cs
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
    }


}
