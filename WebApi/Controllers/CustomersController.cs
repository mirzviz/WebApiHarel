using JwtWebApiTutorial.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.IO;
using WebApi.Services.CustomersService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JwtWebApiTutorial.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public List<Customer> Get()
        {
            return _customerService.Get();
        }
        
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Customer customer)
        {
            if (id != customer.ID)
                return BadRequest("User not found.");

            _customerService.Put(id, customer);

            return Ok();
        }
    }
}
