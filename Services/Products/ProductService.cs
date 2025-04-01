using App.Repositories;
using App.Repositories.Products;
using Microsoft.EntityFrameworkCore;

namespace App.Services.Products;

public class ProductService(IProductRepository productRepository,IUnitOfWork unitOfWork) : IProductService
{
    public async Task<ServiceResult<IEnumerable<ProductDto>>> GetTopPriceProductsAsync(int count)
    {
        var productEntites = await productRepository.GetTopPriceProductsAsync(count);
        var products = productEntites.Select(item => new ProductDto(item.Id, item.Name, item.Price, item.Stock)).AsEnumerable();

        return new ServiceResult<IEnumerable<ProductDto>>()
        {
            Data = products
        };
    }
    public async Task<ServiceResult<IEnumerable<ProductDto>>> GetAllAsync()
    {
        var entities =  await productRepository.GetAll().ToListAsync();
        var products = entities.Select(item => new ProductDto(item.Id, item.Name, item.Price, item.Stock)).AsEnumerable();

        return ServiceResult<IEnumerable<ProductDto>>.Success(products);
    }

    public async Task<ServiceResult<ProductDto>> GetByIdAsync(int id)
    {
        var entity = await productRepository.GetByIdAsync(id);
        if (entity is null)
        {
            return ServiceResult<ProductDto>.Fail($"Product with given id : {id} is not found");
        }
        var product = new ProductDto(entity.Id, entity.Name, entity.Price, entity.Stock);
        return ServiceResult<ProductDto>.Success(product);
    }

    public async Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request){
        var product = new Product { Name = request.Name, Price = request.Price, Stock = request.Stock };
        await productRepository.AddAsync(product);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult<CreateProductResponse>.Success(new CreateProductResponse(product.Id));
    }
    public async Task<ServiceResult> UpdateAsync(int id,UpdateProductRequest request)
    {
        var entity = await productRepository.GetByIdAsync(id);
        // Önce olumsuz durumları ele almaya Fast fail - Guard Clauses denir
        if (entity is null)
        {
            return ServiceResult.Fail($"Product with given id : {id} is not found");
        }

        var product = new Product()
        { Id = id, Name = request.Name, Price = request.Price, Stock = request.Stock };

        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync(); 

        return ServiceResult.Success();
    }
    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var entity = await productRepository.GetByIdAsync(id);
        // Önce olumsuz durumları ele almaya Fast fail - Guard Clauses denir
        if (entity is null)
        {
            return ServiceResult.Fail($"Product with given id : {id} is not found");
        }

        productRepository.Delete(entity);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success();
    }
}
