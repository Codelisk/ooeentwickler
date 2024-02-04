using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ooeentwicklerapi.Host.Migrations
{
    /// <inheritdoc />
    public partial class Three : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "testEntity");

            migrationBuilder.CreateTable(
                name: "accountCompensationEntity",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Wage = table.Column<decimal>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountCompensationEntity", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "accountEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    AccountType = table.Column<int>(type: "INTEGER", nullable: false),
                    DistrictId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "accountProgrammingFrameworkEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProgrammingFrameworkId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountProgrammingFrameworkEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "companyBenefitEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyBenefitEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "companyEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IndustryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanyLocationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FoundingYear = table.Column<int>(type: "INTEGER", nullable: false),
                    DeveloperCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    HowWeDevelopDescription = table.Column<string>(type: "TEXT", nullable: false),
                    CareerLink = table.Column<string>(type: "TEXT", nullable: true),
                    WebsiteLink = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "companyIndustryEntity",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IndustryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyIndustryEntity", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "companyInfrastructureEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    InfrastructureId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyInfrastructureEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "companyLocationEntity",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    Zipcode = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyLocationEntity", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "companyProgrammingFrameworkEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProgrammingFrameworkId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyProgrammingFrameworkEntity", x => x.id);
                });

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
                name: "districtEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districtEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "industryEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_industryEntity", x => x.id);
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

            migrationBuilder.CreateTable(
                name: "issueTrackerEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issueTrackerEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "programmingFrameworkEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ProgrammingLanguageId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programmingFrameworkEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "programmingLanguageEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programmingLanguageEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "repositoryHostingEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repositoryHostingEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "skillsEntity",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PrimaryProgrammingLanguage = table.Column<Guid>(type: "TEXT", nullable: false),
                    SecondaryProgrammingLanguage = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skillsEntity", x => x.AccountId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accountCompensationEntity");

            migrationBuilder.DropTable(
                name: "accountEntity");

            migrationBuilder.DropTable(
                name: "accountProgrammingFrameworkEntity");

            migrationBuilder.DropTable(
                name: "companyBenefitEntity");

            migrationBuilder.DropTable(
                name: "companyEntity");

            migrationBuilder.DropTable(
                name: "companyIndustryEntity");

            migrationBuilder.DropTable(
                name: "companyInfrastructureEntity");

            migrationBuilder.DropTable(
                name: "companyLocationEntity");

            migrationBuilder.DropTable(
                name: "companyProgrammingFrameworkEntity");

            migrationBuilder.DropTable(
                name: "companySkillsEntity");

            migrationBuilder.DropTable(
                name: "districtEntity");

            migrationBuilder.DropTable(
                name: "industryEntity");

            migrationBuilder.DropTable(
                name: "infrastructureEntity");

            migrationBuilder.DropTable(
                name: "issueTrackerEntity");

            migrationBuilder.DropTable(
                name: "programmingFrameworkEntity");

            migrationBuilder.DropTable(
                name: "programmingLanguageEntity");

            migrationBuilder.DropTable(
                name: "repositoryHostingEntity");

            migrationBuilder.DropTable(
                name: "skillsEntity");

            migrationBuilder.CreateTable(
                name: "testEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testEntity", x => x.id);
                });
        }
    }
}
