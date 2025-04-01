using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace App.Repositories.Extensions
{
    /// <summary>
    ///     This class is used to add a new extension method to <typeparamref name="IServiceCollection" />.    
    /// </summary>
    public static class RepositoryExtensions
    {
        /// <summary>
        ///     Adds a new method to <typeparamref name="IServiceCollection" /> for configuring the DbContext.
        /// </summary>
        public static IServiceCollection AddRepository(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                // Configuration üzerinden ConnectionStrings'i oku daha sonra da bunu ConnectionStringOption olarak belirttiğimiz class'a Cast et diyoruz.
                var connectionStrings = configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();
                // burada connectionString!. ifadesi connectionString'in kesinlikle null gelmeyeceğini belirtir.
                options.UseSqlServer(connectionStrings!.SqlServer, sqlServerOptionsAction =>
                {
                    //Migrations klasörünün hangi projede oluşturulacağını belirtir.
                    sqlServerOptionsAction.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.FullName);
                });
            });
            return services; 
        }
    }
}
