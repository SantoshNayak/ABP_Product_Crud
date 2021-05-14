using Abp.Domain.Entities.Auditing;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Models
{
    public class Product : AuditedSoftDeletableEntity<long>
    {
        private Product()
        {

        }       
        [Required]
        public string Name { get; private set; }
        [Required]
        public double Price { get; private set; }       
        public string Description { get; private set; }

        public static Product CreateProduct(string name, double price, string description )
        {
            Product product = new Product()
            {
                Name = name,
                Price = price,
                IsActive = true,
                Description = description
            };
            return product;
        }

        public void UpdateProduct(string name, double price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
               
        }
        public void DeleteProduct()
        {
            IsActive = false;
        }
        
    }
}
