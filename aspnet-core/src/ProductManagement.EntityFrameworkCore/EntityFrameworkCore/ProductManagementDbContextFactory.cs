using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ProductManagement.Configuration;
using ProductManagement.Web;

namespace ProductManagement.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ProductManagementDbContextFactory : IDesignTimeDbContextFactory<ProductManagementDbContext>
    {
        public ProductManagementDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ProductManagementDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ProductManagementDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ProductManagementConsts.ConnectionStringName));

            return new ProductManagementDbContext(builder.Options);
        }
    }
}
