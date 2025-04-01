namespace App.Repositories.Products
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        public Task<IEnumerable<Product>> GetTopPriceProductsAsync(int count);
    }
}
