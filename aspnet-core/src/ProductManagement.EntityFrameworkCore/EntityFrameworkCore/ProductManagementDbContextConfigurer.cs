using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.EntityFrameworkCore
{
    public static class ProductManagementDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ProductManagementDbContext> builder, string connectionString)
        {
            //builder.UseSqlServer(connectionString);
            builder.UseMySql(connectionString, new MySqlServerVersion(new Version(5, 7, 0)));

        }

        public static void Configure(DbContextOptionsBuilder<ProductManagementDbContext> builder, DbConnection connection)
        {
            //builder.UseSqlServer(connection);
            builder.UseMySql(connection, new MySqlServerVersion(new Version(5, 7, 0)));
        }
    }
}
