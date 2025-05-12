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
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            Genre genre1 = new()
            {
                Id = 1,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                Name = "Korku",
            };

            Genre genre2 = new()
            {
                Id = 2,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                Name = "Gerilim",
            };

            builder.HasData(genre1, genre2);
        }
    }
}
