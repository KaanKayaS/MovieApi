using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Persistence.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(new Country
            {
                Id = 1,
                Name = "TR",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });

            builder.HasData(new Country
            {
                Id = 2,
                Name = "ABD",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}
