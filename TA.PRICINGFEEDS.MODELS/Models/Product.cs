using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.PRICINGFEEDS.MODELS
{
    public class Products
    {
        public int ID { get; set; }
        public int StoreId { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime Date { get; set; }
    }
}