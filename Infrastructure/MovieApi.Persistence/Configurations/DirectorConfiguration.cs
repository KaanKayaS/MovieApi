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
            Director director = new()
            {
                Id = 1,
                FullName = "Cristopher Nolan",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

            builder.HasData(director);
        }
    }
}
