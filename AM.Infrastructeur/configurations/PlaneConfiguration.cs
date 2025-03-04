using AM.Applactioncore.Domaine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructeur.Configurations
{
    public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            
            //planId key primaire mtaa plane
            builder.HasKey(p => p.PlaneId);
            //tdabbdelk esm el table
            builder.ToTable("MyPlanes");
            //nbadel el colonne
            builder.Property(p => p.Capacity).HasColumnName("PlanCapacity");
        }
    }
}
