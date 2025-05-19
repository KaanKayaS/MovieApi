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
                MoviePlot = "Filmin odaklandığı yakın gelecekte yeryüzündeki yaşam; artan kuraklık ve iklim değişiklikleri nedeniyle tehlikeye girmiştir. İnsan ırkı yok olma tehlikesiyle karşı karşıyadır. Bu sırada yeni keşfedilen bir solucan deliği, tüm insanlığın umudu hâline gelir. Bir grup astronot-kaşif, buradan geçip boyut değiştirerek daha önce hiçbir insanoğlunun erişemediği yerlere ulaşmak ve insanoğlunun yeni yaşam alanlarını araştırmakla görevlendirilir. Bu kaşifler, geçen 1 saatin dünyadaki 7 yıla bedel olduğu bir ortamda hızlı ve cesur davranmak zorundadır.",
                CountryId = 2,
                DirectorId = 1,
                PublicationDate = new DateTime(2014, 11, 7),
                Duration = new TimeSpan(2, 49, 0),
                Image = "aaa",
                ImdbPoint = 8.7,
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false,
                IsSubtitle = true,
                IsTrDubbing = true,
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
                   new { MoviesId = 1, GenresId = 4 },
                   new { MoviesId = 1, GenresId = 5 },
                   new { MoviesId = 1,  GenresId = 6 }
               ));
        }
    }
}
