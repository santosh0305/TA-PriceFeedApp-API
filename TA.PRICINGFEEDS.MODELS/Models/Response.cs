using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TA.PRICINGFEEDS.ENTITIES.Models
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Result { get; set; }
        public List<string> Messages { get; set; }
    }
}
