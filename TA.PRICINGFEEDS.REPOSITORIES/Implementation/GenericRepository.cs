using Microsoft.EntityFrameworkCore;
using TA.PRICINGFEEDS.DATA.V1;

namespace TA.PRICINGFEEDS.REPOSITORIES
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly PricingDbContext _pricingDbContext;

        protected GenericRepository(PricingDbContext pricingDbContext)
        {
            _pricingDbContext = pricingDbContext;
        }

        public async Task<T> Get(int id)
        {
            return await _pricingDbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _pricingDbContext.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _pricingDbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _pricingDbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _pricingDbContext.Set<T>().Update(entity);
        }
    }
}