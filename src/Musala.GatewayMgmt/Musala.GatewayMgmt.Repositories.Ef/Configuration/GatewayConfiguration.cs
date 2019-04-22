using Musala.GatewayMgmt.Model.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Musala.GatewayMgmt.Repositories.Ef.Configuration
{
    public class GatewayConfiguration : EntityTypeConfiguration<Gateway>
    {
        public GatewayConfiguration()
        {
            // Local properties

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);

            Property(x => x.IPv4)
                .IsRequired()
                .HasMaxLength(15);

            Property(x => x.SerialNumber)
                .IsRequired()
                .HasMaxLength(50);

            HasIndex(x => x.SerialNumber)
                .IsUnique();
        }
    }
}
