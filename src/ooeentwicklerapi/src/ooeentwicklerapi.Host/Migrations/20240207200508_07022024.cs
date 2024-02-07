using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ooeentwicklerapi.Host.Migrations
{
    /// <inheritdoc />
    public partial class _07022024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "skillsEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "repositoryHostingEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "programmingLanguageEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "programmingFrameworkEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "issueTrackerEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "industryEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "districtEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "companyProgrammingLanguageEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "companyProgrammingFrameworkEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "companyLocationEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "companyInfrastructureEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "companyIndustryEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "companyEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "companyBenefitEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "accountProgrammingFrameworkEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "accountEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "accountCompensationEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "infrastructureEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IssueTrackerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RepositoryHostingId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infrastructureEntity", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "infrastructureEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "skillsEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "repositoryHostingEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "programmingLanguageEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "programmingFrameworkEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "issueTrackerEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "industryEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "districtEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "companyProgrammingLanguageEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "companyProgrammingFrameworkEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "companyLocationEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "companyInfrastructureEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "companyIndustryEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "companyEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "companyBenefitEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "accountProgrammingFrameworkEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "accountEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "accountCompensationEntity");
        }
    }
}
