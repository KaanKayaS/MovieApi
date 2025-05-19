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
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.HasData(new Director
            {
                Id = 1,
                FullName = "Cristopher Nolan",
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false
            });

            builder.HasData(new Director
            {
                Id = 2,
                FullName = "Jack Bender",
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false
            });

        }
    }
}
