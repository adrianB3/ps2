using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Data",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValue: new Guid("1fbc674e-77f8-4592-b075-812adc4c5dde")),
                    TimeStamp = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now')"),
                    Pump1State = table.Column<bool>(nullable: false),
                    Pump2State = table.Column<bool>(nullable: false),
                    Pump3State = table.Column<bool>(nullable: false),
                    Pump4State = table.Column<bool>(nullable: false),
                    WaterLevelSensor1State = table.Column<bool>(nullable: false),
                    WaterLevelSensor2State = table.Column<bool>(nullable: false),
                    WaterLevelSensor3State = table.Column<bool>(nullable: false),
                    WaterLevelSensor4State = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Data",
                columns: new[] { "Id", "Pump1State", "Pump2State", "Pump3State", "Pump4State", "WaterLevelSensor1State", "WaterLevelSensor2State", "WaterLevelSensor3State", "WaterLevelSensor4State" },
                values: new object[] { new Guid("21687b99-0470-48dc-b10e-cdb18778cc10"), true, true, false, false, true, true, true, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Data");
        }
    }
}
