using Musala.GatewayMgmt.Model.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Musala.GatewayMgmt.Repositories.Ef.Configuration
{
    public class DeviceConfiguration : EntityTypeConfiguration<Device>
    {
        public DeviceConfiguration()
        {
            // Local properties

            Property(x => x.UID).IsRequired();
            Property(x => x.Vendor).IsRequired().HasMaxLength(30);

            // Foreign Keys
            HasRequired(t => t.Gateway)
               .WithMany(m => m.Devices);
        }
    }
}
