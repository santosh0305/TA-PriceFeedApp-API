using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TA.PRICINGFEEDS.ENTITIES.Models;
using TA.PRICINGFEEDS.MODELS;
using TA.PRICINGFEEDS.REPOSITORIES.Interfaces;

namespace TA.PRICINGFEEDS.API.V1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("*")]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet, Route("Health")]
        public string Health()
        {
            return new string("Products Service Working Fine !!");
        }


        [HttpPost(Name = "Post")]
        public async Task<Response> Post(Product product)
        {
            var response = new Response()
            {
                Messages = new List<string>()
            };

            try
            {
                var result = _unitOfWork.Products.Add(product);
                _unitOfWork.Complete();

                response.Result = result;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Messages.Add(e.Message);
            }

            return response;
        }

        [HttpPut(Name = "Put")]
        public async Task<Response> Put(Product product)
        {
            var response = new Response()
            {
                Messages = new List<string>()
            };

            try
            {
                _unitOfWork.Products.Update(product);
                _unitOfWork.Complete();

                response.Result = "Product Updated Successfully.";
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Messages.Add(e.Message);
            }

            return response;
        }

        [HttpGet, Route("GetAllProducts")]
        public async Task<Response> GetAll()
        {
            var response = new Response()
            {
                Messages = new List<string>()
            };

            try
            {
                response.Result = await _unitOfWork.Products.GetAll();
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Messages.Add(e.Message);
            }

            return response;
        }

        [HttpGet, Route("GetProductById")]
        public async Task<Response> GetProductById(int id)
        {
            var response = new Response()
            {
                Messages = new List<string>()
            };

            try
            {
                response.Result = await _unitOfWork.Products.Get(id);
                response.StatusCode = HttpStatusCode.OK;
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