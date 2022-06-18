using DriverLog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriverLog.Persistence.EF.DriverLogs
{
    public class DriverLogEntityMap : IEntityTypeConfiguration<DriveLog>
    {
        public void Configure(EntityTypeBuilder<DriveLog> builder)
        {
            builder.ToTable("DriverLogs");
            builder.HasKey("Id");

            builder.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(_ => _.CreationDate).IsRequired();
            builder.Property(_ => _.DriverId).IsRequired();
        }
    }
}
