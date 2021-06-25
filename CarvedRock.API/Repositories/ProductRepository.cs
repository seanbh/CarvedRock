using CarvedRock.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetAllProducts()
        {    
            var products = new List<Product>()
            { new Product() { Id = 1, Name = "Product 1" } };

            return products;
        }
    }
}
