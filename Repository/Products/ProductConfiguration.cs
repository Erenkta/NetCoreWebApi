using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repositories.Products;

    /// <summary>
    ///     Configures the entity of type <typeparamref name="Product" />.
    ///     We should use configuration class instead of attributes
    /// </summary>
    public class ProductConfiguration : IEntityTypeConfiguration<Product> 
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Name).IsRequired().HasMaxLength(150);
            builder.Property(entity => entity.Price).IsRequired().HasColumnType("decimal(18,2)"); // toplamda 18 karakterdir ve virgülden sonra 2 karakter olabilir.
            builder.Property(entity => entity.Stock).IsRequired();
        }
    }

