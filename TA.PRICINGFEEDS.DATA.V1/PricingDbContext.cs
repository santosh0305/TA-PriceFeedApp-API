using Microsoft.EntityFrameworkCore;
using TA.PRICINGFEEDS.MODELS;

namespace TA.PRICINGFEEDS.DATA.V1
{
    public class PricingDbContext : DbContext
    {
        public PricingDbContext(DbContextOptions<PricingDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}