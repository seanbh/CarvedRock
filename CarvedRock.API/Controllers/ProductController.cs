using CarvedRock.API.Models;
using CarvedRock.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repo;
		private readonly ILogger<ProductController> logger;

		public ProductController(IProductRepository repo, ILogger<ProductController> logger)
        {
            this.repo = repo;
			this.logger = logger;
		}
        [HttpGet]
        public IActionResult Get()
        {
            logger.LogInformation("GetProducts called");
            return Ok(repo.GetAllProducts());
        }
    }
}
