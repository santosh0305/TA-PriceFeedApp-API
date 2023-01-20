using TA.PRICINGFEEDS.REPOSITORIES.Interface;
using TA.PRICINGFEEDS.SERVICE.Interface;

namespace TA.PRICINGFEEDS.REPOSITORIES.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        int Complete();
    }
}
