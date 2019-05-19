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
                    Id = table.Column<Guid>(nullable: false, defaultValue: new Guid("0dab65ce-3c80-4ff1-93cc-36755b2c16b0")),
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
                values: new object[] { new Guid("155682a1-8f0d-4cf6-a3bd-7f1a16870eac"), true, true, false, false, true, true, true, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Data");
        }
    }
}
