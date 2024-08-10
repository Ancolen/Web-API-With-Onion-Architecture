using Bogus;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Faker faker = new ("tr");

            Product product1 = new()
            {
                ID = 1,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandID = 1,
                Discount = faker.Random.Decimal(0, 10),
                Price = faker.Finance.Amount(50, 1000),
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };
            Product product2 = new()
            {
                ID = 2,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandID = 2,
                Discount = faker.Random.Decimal(0, 10),
                Price = faker.Finance.Amount(50, 1000),
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };
            Product product3 = new()
            {
                ID = 3,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandID = 3,
                Discount = faker.Random.Decimal(0, 10),
                Price = faker.Finance.Amount(50, 1000),
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };
            builder.HasData(product1, product2, product3);
        }
    }
}
