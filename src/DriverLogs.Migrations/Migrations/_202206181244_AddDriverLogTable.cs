using FluentMigrator;

namespace DriverLogs.Migrations.Migrations
{
    [Migration(202206181244)]
    public class _202206181244_AddDriverLogTable : Migration
    {
        public override void Up()
        {
            Create.Table("DriverLogs")
                .WithColumn("Id").AsInt32().Identity().NotNullable().PrimaryKey()
                .WithColumn("DriverId").AsGuid().NotNullable()
                .WithColumn("CreationDate").AsDateTime2().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("DriverLogs");
        }
    }
}
