using CarvedRock.API.Models;
using System.Collections.Generic;

namespace CarvedRock.API.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
    }
}