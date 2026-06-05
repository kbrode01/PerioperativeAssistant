using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerioperativeAssistant.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurgicalCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SurgeonName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AnesthesiologistName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CrnaName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AnesTechName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SurgeryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcedureType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AnesthesiaType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurgicalCases", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurgicalCases");
        }
    }
}
