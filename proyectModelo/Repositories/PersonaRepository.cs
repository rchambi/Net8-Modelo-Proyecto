using Microsoft.EntityFrameworkCore;
using proyectModelo.Modelos;

namespace proyectModelo.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Persona>> GetAll()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona> GetById(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task Add(Persona entity)
        {
            await _context.Personas.AddAsync(entity);
        }

        public void Update(Persona entity)
        {
            _context.Personas.Update(entity);
        }

        public void Delete(Persona entity)
        {
            _context.Personas.Remove(entity);
        }

        public IQueryable<Persona> GetQueryable()
        {
            return _context.Personas.AsQueryable();
        }
    }
}
