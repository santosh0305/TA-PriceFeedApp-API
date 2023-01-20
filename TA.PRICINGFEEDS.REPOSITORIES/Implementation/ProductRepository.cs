using TA.PRICINGFEEDS.DATA.V1;
using TA.PRICINGFEEDS.MODELS;
using TA.PRICINGFEEDS.REPOSITORIES.Interface;

namespace TA.PRICINGFEEDS.REPOSITORIES.Implementation
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(PricingDbContext pricingDbContext) : base(pricingDbContext)
        {

        }
    }
}
