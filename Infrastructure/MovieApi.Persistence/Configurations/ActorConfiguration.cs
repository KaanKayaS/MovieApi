using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace MovieApi.Persistence.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasData(
               new Actor
               {
                   Id = 1,
                   FullName = "Matthew McConaughey",
                   Image = "aa",
                   CreatedDate = DateTime.UtcNow,
                   IsDeleted = false
               },
               new Actor
               {
                   Id = 2,
                   FullName = "Jessica Chastain",
                   Image = "aa",
                   CreatedDate = DateTime.UtcNow,
                   IsDeleted = false
               },

               new Actor
               {
                   Id = 3,
                   FullName = "Harold Perrineau Jr.",
                   Image = "aa",
                   CreatedDate = DateTime.UtcNow,
                   IsDeleted = false
               },

                new Actor
                {
                    Id = 4,
                    FullName = "Scott McCord",
                    Image = "aa",
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false
                }
           );
        }
    }
}
