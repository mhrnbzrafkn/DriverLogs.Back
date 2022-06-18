using DriverLog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriverLog.Persistence.EF.Drivers
{
    public class DriverEntityMap : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("Drivers");
            builder.HasKey("Id");

            builder.Property(_ => _.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(_ => _.FullName).HasMaxLength(100).IsRequired();
            builder.Property(_ => _.CreationDate).IsRequired();
        }
    }
}
