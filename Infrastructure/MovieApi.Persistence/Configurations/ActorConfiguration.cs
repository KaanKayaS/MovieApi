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
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasData(
               new Actor
               {
                   Id = 1,
                   Name = "John",
                   Surname = "Smith",
                   Image = "aa",
                   CreatedDate = DateTime.Now,
                   IsDeleted = false
               },
               new Actor
               {
                   Id = 2,
                   Name = "Emily",
                   Surname = "Blunt",
                   Image = "aa",
                   CreatedDate = DateTime.Now,
                   IsDeleted = false
               }
           );
        }
    }
}
