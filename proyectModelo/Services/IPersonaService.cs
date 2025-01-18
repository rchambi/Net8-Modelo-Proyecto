using proyectModelo.Modelos;

namespace proyectModelo.Services
{
    public interface IPersonaService : IGenericService<Persona>
    {
        public int GetCantidadPersonas();
    }

}
