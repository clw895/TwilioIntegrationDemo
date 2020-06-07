using System;
using System.Collections.Generic;
using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            }).Take(3).ToList();

            var response = new AutopilotResponse {
               Actions = new List<object>()
            };

            foreach (var product in products)
            {
                response.Actions.Add(new 
                {
                    show = new Show
                    {
                        Body = product.Title,
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
        public IActionResult PlaceOrder([FromForm]string memory)
        {
            var json = JObject.Parse(memory);
            var answers = json["twilio"]["collected_data"]["order_product"]["answers"];
            var firstName = answers["first_name"]["answer"].ToString();
            var productName = answers["product_name"]["answer"].ToString();
            var product_count = answers["product_count"]["answer"].ToString();

            var response = new {
                actions = new[]{
                    new { say = $"Thanks for your order {firstName}. We will send out an order of {product_count} {productName} shortly."}
                }
            };

            return new JsonResult(response);

        }
    }
}
