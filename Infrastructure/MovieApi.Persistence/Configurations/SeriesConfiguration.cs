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
    public class SeriesConfiguration : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> builder)
        {
            builder.HasData(new Series
            {
                Id = 1,
                Name = "From",
                SeriesPlot = "İsteksiz sakinler, normallik duygusunu sürdürmek ve bir çıkış yolu aramak için savaşırken, aynı zamanda, güneş battığında ortaya çıkan korkunç yaratıklar da dahil olmak üzere, çevredeki ormanın tehditlerine karşı da hayatta kalmak zorundadırlar.",
                CountryId = 2,
                Image="aaa",
                DirectorId = 2,
                ImdbPoint = 7.8,
                SeasonCount = 3,
                IsSubtitle = true,
                IsTrDubbing = true,
                PublicationDate = new DateTime(2022),
            });

            builder
               .HasMany(m => m.Actors)
               .WithMany(a => a.Series)
               .UsingEntity(j => j.HasData(
                   new { SeriesId = 1, ActorsId = 3 },
                   new { SeriesId = 1, ActorsId = 4 }
               ));

            builder
             .HasMany(m => m.Genres)
             .WithMany(a => a.Series)
             .UsingEntity(j => j.HasData(
                 new { SeriesId = 1, GenresId = 4 },
                 new { SeriesId = 1, GenresId = 1 },
                 new { SeriesId = 1, GenresId = 2 }
             ));
        }
    }
}
