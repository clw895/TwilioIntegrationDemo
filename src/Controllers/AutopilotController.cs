using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using static ContosoCrafts.WebSite.Models.AutopilotResponse;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContosoCraftsController : ControllerBase
    {
        public ContosoCraftsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            var products = ProductService.GetProducts().Select(x => new 
            {
                x.Id,
                x.Image,
                x.Title,
                x.Description
            }).ToList();

            var response = new AutopilotResponse {
               Actions = new List<object>()
            };

            foreach (var product in products)
            {
                response.Actions.Add(new 
                {
                    show = new Show
                    {
                        Body = product.Description,
                        Images = new List<Show.Image>
                        {
                            {new Show.Image
                            {
                                Url = new Uri(product.Image),
                                Label = product.Title
                            }}
                        }
                    }
                });
            }
            return new JsonResult(response);
        }
    
        [HttpPost("order")]
        public IActionResult PlaceOrder(string order)
        {
            return NoContent();
        }
    }
}
