namespace App.Services.Products
{
    /// <summary>
    /// We should use DTOs for each entity because we don't want to use entities directly in our operations.
    ///<para> When creating a DTO for an entity, we should use the record keyword instead of class keyword. </para>
    /// <para> This ensures that DTO properties remain immutable and safe from unintended modifications. </para>
    /// </summary>
    public record ProductDto(int Id,string Name,decimal Price,int Stock);
}
