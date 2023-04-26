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
    internal class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder.HasKey(p => p.PlaneId);  // assign primary key 
            builder.ToTable("MyPlanes"); // rename table name 
            builder.Property(p => p.Capacity).HasColumnName("plane capacity"); // rename column name     
        }
    }
}
