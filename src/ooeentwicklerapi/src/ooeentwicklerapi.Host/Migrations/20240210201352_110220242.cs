using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ooeentwicklerapi.Host.Migrations
{
    /// <inheritdoc />
    public partial class _110220242 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DistrictId",
                table: "companyLocationEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "companyLocationEntity");
        }
    }
}
