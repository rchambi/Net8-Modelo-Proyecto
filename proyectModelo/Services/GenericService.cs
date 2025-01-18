using proyectModelo.Repositories;
using proyectModelo.UnitOfWork;

namespace proyectModelo.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository;

        public GenericService(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Add(T entity)
        {
            await _repository.Add(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Update(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _repository.GetById(id);
            if (entity != null)
            {
                _repository.Delete(entity);
                await _unitOfWork.CompleteAsync();
            }
        }
    }

}
