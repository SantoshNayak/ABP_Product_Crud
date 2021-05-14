using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ProductManagement.Authorization.Roles;
using ProductManagement.Authorization.Users;
using ProductManagement.MultiTenancy;
using ProductManagement.Models;
namespace ProductManagement.EntityFrameworkCore
{
    public class ProductManagementDbContext : AbpZeroDbContext<Tenant, Role, User, ProductManagementDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Product> Products { get; set; }
        public ProductManagementDbContext(DbContextOptions<ProductManagementDbContext> options)
            : base(options)
        {
        }
    }
}
