using System.Linq;

namespace RockBandLeaderBoards.Services.Contracts
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(IQueryable<T> entities);
        void Delete(T entity);
        void Delete(int id);
    }
}
