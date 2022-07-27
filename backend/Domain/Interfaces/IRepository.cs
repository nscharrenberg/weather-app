using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        T? GetById(int id);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
    }
}
