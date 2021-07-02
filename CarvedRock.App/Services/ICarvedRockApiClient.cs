using CarvedRock.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarvedRock.App.Services
{
    public interface ICarvedRockApiClient
    {
        Task<List<Product>> GetProducts();
    }
}