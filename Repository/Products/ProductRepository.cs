namespace App.Repositories.Products
{
    public class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepository
    {
        public Task<IEnumerable<Product>> GetTopPriceProductsAsync(int count)
        {
            return Task.FromResult(base.GetAll().OrderByDescending(x => x.Price).Take(count).AsEnumerable());
        }
    }
}
