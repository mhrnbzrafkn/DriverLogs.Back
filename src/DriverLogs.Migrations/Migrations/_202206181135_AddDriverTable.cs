using FluentMigrator;

namespace DriverLogs.Migrations.Migrations
{
    [Migration(202206181135)]
    public class _202206181135_AddDriverTable : Migration
    {
        public override void Up()
        {
            Create.Table("Drivers")
                .WithColumn("Id")
                .AsGuid().NotNullable().PrimaryKey()
                .WithColumn("FullName")
                .AsString().NotNullable()
                .WithColumn("CreationDate")
                .AsDateTime2().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Drivers");
        }
    }
}
