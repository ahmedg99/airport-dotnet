using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Am.Infrastructure.Configuration
{
    public class FlighConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            // config de *--* en changeant le nom de la table associsative

            builder.HasMany(p => p.Passengers).WithMany(p => p.Flights)
                .UsingEntity(t => t.ToTable("vols"));


            // config 1-*
            builder.HasOne(p => p.Plane)
                .WithMany(p => p.flights)
                .OnDelete(DeleteBehavior.Cascade);


            



        }

             
    }
}
