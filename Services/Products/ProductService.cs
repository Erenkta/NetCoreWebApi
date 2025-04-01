using App.Repositories.Products;

namespace App.Services.Products
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public Task<IEnumerable<Product>> GetTopPriceProductsAsync(int count)
        {
            return productRepository.GetTopPriceProductsAsync(count);
        }
    }
}
