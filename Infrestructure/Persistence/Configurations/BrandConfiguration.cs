using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Bogus;

namespace Persistence.Configurations
{
    //Deneme Dataları
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x=> x.Name).HasMaxLength(256);

            Faker faker     = new("tr");

            Brand brand1    = new()
            {
                ID          = 1,
                Name        = faker.Commerce.Department(),
                CreatedDate = DateTime.Now,
                IsDeleted   = false,
            };
            Brand brand2    = new()
            {
                ID          = 2,
                Name        = faker.Commerce.Department(),
                CreatedDate = DateTime.Now,
                IsDeleted   = false,
            };
            Brand brand3    = new()
            {
                ID          = 3,
                Name        = faker.Commerce.Department(),
                CreatedDate = DateTime.Now,
                IsDeleted   = true,
            };
            builder.HasData(brand1, brand2, brand3);
        }
    }
}
