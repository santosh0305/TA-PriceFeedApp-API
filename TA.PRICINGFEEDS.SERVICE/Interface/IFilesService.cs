using TA.PRICINGFEEDS.ENTITIES.Models;

namespace TA.PRICINGFEEDS.SERVICE.Interface
{
    public interface IFilesService
    {
        Task<IEnumerable<FileRows>> ReadCsvFileData<T>(Stream file);
    }
}
