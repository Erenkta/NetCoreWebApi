using App.Repositories.Products;
using App.Repositories;

namespace App.Services.Products
{
    public interface IProductService
    {
        Task<ServiceResult<IEnumerable<ProductDto>>> GetTopPriceProductsAsync(int count);
        Task<ServiceResult<IEnumerable<ProductDto>>> GetAllAsync();

        Task<ServiceResult<ProductDto>> GetByIdAsync(int id);
        Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest request);
        Task<ServiceResult> DeleteAsync(int id);
    }
}

