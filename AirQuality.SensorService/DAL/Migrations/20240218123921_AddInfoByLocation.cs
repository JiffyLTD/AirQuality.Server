using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirQuality.SensorService.Migrations
{
    /// <inheritdoc />
    public partial class AddInfoByLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "infos_by_location",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    station_id = table.Column<Guid>(type: "uuid", nullable: false),
                    location_name = table.Column<string>(type: "text", nullable: false),
                    avg_temperature = table.Column<float>(type: "real", nullable: false),
                    avg_humidity = table.Column<int>(type: "integer", nullable: false),
                    avg_pm_1 = table.Column<int>(type: "integer", nullable: false),
                    avg_pm_2_5 = table.Column<int>(type: "integer", nullable: false),
                    avg_pm_10 = table.Column<int>(type: "integer", nullable: false),
                    avg_co = table.Column<int>(type: "integer", nullable: false),
                    avg_pressure = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_infos_by_location", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
