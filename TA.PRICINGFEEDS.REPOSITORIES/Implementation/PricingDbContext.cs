using Microsoft.EntityFrameworkCore;
using TA.PRICINGFEEDS.MODELS;

namespace TA.PRICINGFEEDS.REPOSITORIES
{
    public class PricingDbContext : DbContext
    {
        public PricingDbContext(DbContextOptions<PricingDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=TADB;Trusted_Connection=True;");
        //}

        public DbSet<Product> Products { get; set; }
    }
}