using TA.PRICINGFEEDS.DATA.V1;
using TA.PRICINGFEEDS.REPOSITORIES.Interface;
using TA.PRICINGFEEDS.REPOSITORIES.Interfaces;

namespace TA.PRICINGFEEDS.REPOSITORIES.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PricingDbContext _pricingDbContext;
        public IProductRepository Products { get; }

        public UnitOfWork(PricingDbContext pricingDbContext, IProductRepository catalogueRepository)
        {
            this._pricingDbContext = pricingDbContext;

            this.Products = catalogueRepository;
        }
        public int Complete()
        {
            return _pricingDbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _pricingDbContext.Dispose();
            }
        }
    }
}
