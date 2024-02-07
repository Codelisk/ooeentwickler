using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ooeentwicklerapi.Host.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companySkillsEntity");

            migrationBuilder.DropTable(
                name: "infrastructureEntity");

            migrationBuilder.DropColumn(
                name: "CompanyLocationId",
                table: "companyEntity");

            migrationBuilder.DropColumn(
                name: "IndustryId",
                table: "companyEntity");

            migrationBuilder.CreateTable(
                name: "companyProgrammingLanguageEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProgrammingLanguageId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyProgrammingLanguageEntity", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companyProgrammingLanguageEntity");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyLocationId",
                table: "companyEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IndustryId",
                table: "companyEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "companySkillsEntity",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SkillsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companySkillsEntity", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "infrastructureEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IssueTrackerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RepositoryHostingId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infrastructureEntity", x => x.id);
                });
        }
    }
}
