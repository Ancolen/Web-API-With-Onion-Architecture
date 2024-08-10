using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category category1 = new()
            {
                ID = 1,
                Name = "Electronic",
                QueueID = 1,
                ParentID = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };
            Category category2 = new()
            {
                ID = 2,
                Name = "House & Life",
                QueueID = 2,
                ParentID = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };
            Category category3 = new()
            {
                ID = 3,
                Name = "Cosmetic",
                QueueID = 3,
                ParentID = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };
            Category Parent1 = new()
            {
                ID = 4,
                Name = "Computer",
                QueueID = 1,
                ParentID = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };
            Category Paren2 = new()
            {
                ID = 5,
                Name = "Furniture",
                QueueID = 1,
                ParentID = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };
            Category Parent3 = new()
            {
                ID = 6,
                Name = "Make-up",
                QueueID = 1,
                ParentID = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };
            builder.HasData(category1, category2, category3);
        }
    }
}
