﻿using Bogus;
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
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Faker faker = new("tr");

            Detail detail1 = new()
            {
                ID = 1,
                Title = faker.Lorem.Sentence(1), //
                Description = faker.Lorem.Sentence(3),
                CategoryID = 1,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };
            Detail detail2 = new()
            {
                ID = 2,
                Title = faker.Lorem.Sentence(2), //
                Description = faker.Lorem.Sentence(3),
                CategoryID = 4,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };
            Detail detail3 = new()
            {
                ID = 3,
                Title = faker.Lorem.Sentence(3), //
                Description = faker.Lorem.Sentence(3),
                CategoryID = 5,
                CreatedDate = DateTime.Now,
                IsDeleted = true,
            };
            builder.HasData(detail1, detail2, detail3);
        }
    }
}
