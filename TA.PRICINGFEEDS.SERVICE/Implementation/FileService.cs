using CsvHelper;
using TA.PRICINGFEEDS.ENTITIES.Models;
using TA.PRICINGFEEDS.SERVICE.Interface;

namespace TA.PRICINGFEEDS.SERVICE.Implementation
{
    public class FileService : IFilesService
    {
        public async Task<IEnumerable<FileRows>> ReadCsvFileData<T>(Stream file)
        {
            List<FileRows> rows = new List<FileRows>();
            try
            {
                var reader = new StreamReader(file);
                var csv = new CsvReader(reader);

                var records = csv.GetRecords<T>().ToList();

                foreach (var record in records)
                {
                    FileRows row = new FileRows();
                    row.StoreId = (record as FileRows).StoreId;
                    row.SKU = (record as FileRows).SKU;
                    row.ProductName = (record as FileRows).ProductName;
                    row.ProductPrice = (record as FileRows).ProductPrice;
                    row.Date = (record as FileRows).Date;

                    rows.Add(row);
                }
            }
            catch (Exception e)
            {
                rows = new List<FileRows>();
            }

            return rows;
        }
    }
}
