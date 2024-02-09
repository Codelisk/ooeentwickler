using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ooeentwicklerapi.Host.Migrations
{
    /// <inheritdoc />
    public partial class _09022024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companyLogoEntity",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    bytes = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyLogoEntity", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "companyPresentationImageEntity",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    bytes = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyPresentationImageEntity", x => x.CompanyId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companyLogoEntity");

            migrationBuilder.DropTable(
                name: "companyPresentationImageEntity");
        }
    }
}
