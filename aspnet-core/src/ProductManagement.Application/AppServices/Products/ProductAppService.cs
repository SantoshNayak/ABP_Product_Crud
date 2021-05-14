using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProductManagement.AppServices.Products.Dto;
using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.AppServices.Products
{
    [AbpAllowAnonymous]
    public class ProductAppService : ApplicationService, IProductAppService
    {

        private readonly IRepository<Product, long> _productRepository;
       
        public ProductAppService(IRepository<Product, long> productRepository)
        {
            _productRepository = productRepository;            
        }

        public async Task<ProductDto> CreateProduct(CreateProductDto input)
        {         
                Product product = Product.CreateProduct(input.Name, input.Price, input.Description);
                await _productRepository.InsertAsync(product);
                await CurrentUnitOfWork.SaveChangesAsync();
                return ObjectMapper.Map<ProductDto>(product);           
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            List<Product> product = await _productRepository.GetAll().Where(p => p.IsActive == true).ToListAsync();
            return ObjectMapper.Map<List<ProductDto>>(product);
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            Product product =await _productRepository.GetAll().Where(p => p.Id == id).FirstOrDefaultAsync();
            return ObjectMapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProduct(UpdateProductDto input)
        {
            Product product = await _productRepository.GetAll().Where(p => p.Id == input.Id).FirstOrDefaultAsync();
            product.UpdateProduct(input.Name, input.Price, input.Description);
            _productRepository.Update(product);
            return ObjectMapper.Map<ProductDto>(product);

        }

        public async Task<ProductDto> DeleteProduct(int id)
        {
            Product product = await _productRepository.GetAll().Where(p => p.Id == id).FirstOrDefaultAsync();
            product.DeleteProduct();
            _productRepository.Update(product);
            return ObjectMapper.Map<ProductDto>(product);
        }

    }
}
