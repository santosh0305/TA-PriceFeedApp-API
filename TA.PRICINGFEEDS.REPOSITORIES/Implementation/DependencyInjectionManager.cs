using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TA.PRICINGFEEDS.DATA.V1;
using TA.PRICINGFEEDS.REPOSITORIES.Interface;
using TA.PRICINGFEEDS.REPOSITORIES.Interfaces;
using TA.PRICINGFEEDS.SERVICE.Implementation;
using TA.PRICINGFEEDS.SERVICE.Interface;

namespace TA.PRICINGFEEDS.REPOSITORIES.Implementation
{
    public static class DependencyInjectionManager
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IFilesService, FileService>();
            services.AddTransient<IProductsService, ProductsService>();

            services.AddDbContext<PricingDbContext>(options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TADB;Trusted_Connection=True"));
            return services;
        }
    }
}
