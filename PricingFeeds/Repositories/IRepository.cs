using System.Linq;

namespace TA.PRICINGFEEDS.REPOSITORIES.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }
        void Remove(T entity);
        void Add(T entity);
    }
}
