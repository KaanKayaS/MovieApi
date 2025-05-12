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
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(new Movie
            {
                Id = 1,
                Name = "Yıldızlararası",
                MoviePlot = "gerilim dolu bir kovalamaca",
                CountryId = 1,
                DirectorId = 1,
                PublicationDate = DateTime.Now,
                Duration = new TimeSpan(2, 30, 0),
                Image = "aaa",
                ImdbPoint = 9.5,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });

            builder
                .HasMany(m => m.Actors)
                .WithMany(a => a.Movies)
                .UsingEntity(j => j.HasData(
                    new { MoviesId = 1, ActorsId = 1 },
                    new { MoviesId = 1, ActorsId = 2 }
                ));

            builder
               .HasMany(m => m.Genres)
               .WithMany(a => a.Movies)
               .UsingEntity(j => j.HasData(
                   new { MoviesId = 1, GenresId = 1 },
                   new { MoviesId = 1, GenresId = 2 }
               ));
        }
    }
}
