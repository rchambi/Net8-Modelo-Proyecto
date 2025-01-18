using proyectModelo.Modelos;
using proyectModelo.Repositories;

namespace proyectModelo.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Personas = new PersonaRepository(_context);
        }

        public IRepository<Persona> Personas { get; private set; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
