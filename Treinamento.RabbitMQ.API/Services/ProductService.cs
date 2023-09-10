using Treinamento.RabbitMQ.API.Data;
using Treinamento.RabbitMQ.API.Models;

namespace Treinamento.RabbitMQ.API.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _dbContext;

        public ProductService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetProductList()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        public Product AddProduct(Product product)
        {
            var result = _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public Product UpdateProduct(Product product)
        {
            var result = _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteProduct(int Id)
        {
            var filteredData = _dbContext.Products.Where(x => x.Id == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}
