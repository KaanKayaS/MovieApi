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
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false,
                Name = "Korku",
            };

            Genre genre2 = new()
            {
                Id = 2,
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false,
                Name = "Gerilim",
            };

            Genre genre3 = new()
            {
                Id = 3,
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false,
                Name = "Aile",
            };

            Genre genre4 = new()
            {
                Id = 4,
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false,
                Name = "Bilim Kurgu",
            };

            Genre genre5 = new()
            {
                Id = 5,
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false,
                Name = "Aksiyon",
            };

            Genre genre6 = new()
            {
                Id = 6,
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false,
                Name = "Macera",
            };

            Genre genre7 = new()
            {
                Id = 7,
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false,
                Name = "Komedi",
            };


            builder.HasData(genre1, genre2, genre3, genre4, genre5, genre6, genre7);
        }
    }
}
