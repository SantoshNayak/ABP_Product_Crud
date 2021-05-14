using Abp.Application.Services;
using ProductManagement.AppServices.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.AppServices.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<ProductDto> CreateProduct(CreateProductDto input);
    }
}
