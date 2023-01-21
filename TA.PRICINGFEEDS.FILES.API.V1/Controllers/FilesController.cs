using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TA.PRICINGFEEDS.ENTITIES.Models;
using TA.PRICINGFEEDS.MODELS;
using TA.PRICINGFEEDS.REPOSITORIES.Interfaces;
using TA.PRICINGFEEDS.SERVICE.Interface;

namespace TA.PRICINGFEEDS.FILES.API.V1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("*")]
    public class FilesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFilesService _filesService;
        public FilesController(IUnitOfWork unitOfWork, IFilesService filesService)
        {
            _unitOfWork = unitOfWork;
            _filesService = filesService;
        }

        [HttpGet, Route("Health")]
        public string Health()
        {
            return new string("Products Service Working Fine !!");
        }


        [HttpPost, Route("Upload")]
        public async Task<Response> Upload([FromForm] IFormFileCollection file)
        {
            var response = new Response()
            {
                Messages = new List<string>()
            };

            if (file == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Messages.Add("Please Upload File.");
            }

            try
            {
                var records = await _filesService.ReadCsvFileData<FileRows>(file[0].OpenReadStream());
                response.Result = records;
                response.StatusCode = HttpStatusCode.OK;

                foreach (var record in records)
                {
                    Product product = new Product()
                    {
                        StoreId = record.StoreId,
                        SKU = record.SKU,
                        ProductName = record.ProductName,
                        ProductPrice = record.ProductPrice,
                        Date = record.Date
                    };

                    _unitOfWork.Products.Add(product);
                    _unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Messages.Add(e.Message);
            }

            return response;
        }
    }
}