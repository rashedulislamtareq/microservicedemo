using Catalog.API.Interfaces.Manager;
using Catalog.API.Models;
using Catalog.API.Repository;
using MongoRepo.Manager;

namespace Catalog.API.Manager
{
    public class ProductManager : CommonManager<Product>, IProductManager
    {
        public ProductManager() : base(new ProductRepository())
        {
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return GetAll(x => x.Category.ToLower() == category.ToLower());
        }
    }
}
