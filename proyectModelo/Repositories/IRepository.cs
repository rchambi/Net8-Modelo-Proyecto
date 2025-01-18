using System.Collections.Generic;

namespace proyectModelo.Repositories
{
    // RegistroPersonas.Data/Repositories/IRepository.cs

    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetQueryable();

    }

}
