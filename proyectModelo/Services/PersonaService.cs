using proyectModelo.Modelos;
using proyectModelo.Repositories;
using proyectModelo.Services;
using proyectModelo.UnitOfWork;

namespace proyectModelo.Services
{
    public class PersonaService : GenericService<Persona>, IPersonaService //SIN INTERFAZ
    //public class PersonaService : IGenericService<Persona>, IPersonaService //USANDO INTERFACE el tema aqui es q se tiene q implementar todos la interfaz y por ende no tiene mucho sentido
    {

        private readonly IRepository<Persona> _repository;
        public PersonaService(IUnitOfWork unitOfWork, IRepository<Persona> repository) : base(unitOfWork, repository) { _repository = repository; }  //SIN INTERFAZ



        //private readonly IUnitOfWork _unitOfWork;
        //private readonly IRepository<Persona> _repository;
        //private readonly IPersonaRepository _personaRepository;
        //public PersonaService(IUnitOfWork unitOfWork, IRepository<Persona> repository, IPersonaRepository personaRepository) //USANDO INTERFACE
        //{ _unitOfWork = unitOfWork; _repository = repository; _personaRepository = personaRepository; }
        public int GetCantidadPersonas() => _repository.GetQueryable().Count();
    }

}