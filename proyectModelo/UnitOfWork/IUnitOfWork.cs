using proyectModelo.Modelos;
using proyectModelo.Repositories;

namespace proyectModelo.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Persona> Personas { get; }
        Task CompleteAsync();
    }

}
