using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ooeentwicklerapi.Host.Migrations
{
    /// <inheritdoc />
    public partial class _10022024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "districtImageEntity",
                columns: table => new
                {
                    DistrictId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    bytes = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districtImageEntity", x => x.DistrictId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "districtImageEntity");
        }
    }
}
