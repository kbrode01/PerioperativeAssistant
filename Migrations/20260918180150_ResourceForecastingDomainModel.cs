using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerioperativeAssistant.Migrations
{
    /// <inheritdoc />
    public partial class ResourceForecastingDomainModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnesTechName",
                table: "SurgicalCases");

            migrationBuilder.DropColumn(
                name: "AnesthesiologistName",
                table: "SurgicalCases");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "SurgicalCases");

            migrationBuilder.RenameColumn(
                name: "SurgeryDate",
                table: "SurgicalCases",
                newName: "ScheduledStart");

			migrationBuilder.DropColumn(
				name: "SurgeonName",
				table: "SurgicalCases");

			migrationBuilder.DropColumn(
				name: "CrnaName",
				table: "SurgicalCases");

			migrationBuilder.AddColumn<string>(
				name: "Service",
				table: "SurgicalCases",
				type: "nvarchar(100)",
				maxLength: 100,
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<string>(
				name: "ProcedureCode",
				table: "SurgicalCases",
				type: "nvarchar(100)",
				maxLength: 100,
				nullable: false,
				defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ActualDurationMinutes",
                table: "SurgicalCases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualEnd",
                table: "SurgicalCases",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualStart",
                table: "SurgicalCases",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSynthetic",
                table: "SurgicalCases",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "SurgicalCases",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProcedureCodeSystem",
                table: "SurgicalCases",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ScheduledDurationMinutes",
                table: "SurgicalCases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ResourceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Variant = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsReusable = table.Column<bool>(type: "bit", nullable: false),
                    RequiresReprocessing = table.Column<bool>(type: "bit", nullable: false),
                    IsConsumable = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceInventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceTypeId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    UnavailableQuantity = table.Column<int>(type: "int", nullable: false),
                    MinimumDesiredQuantity = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSynthetic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceInventories_ResourceTypes_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResourcePredictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurgicalCaseId = table.Column<int>(type: "int", nullable: false),
                    ResourceTypeId = table.Column<int>(type: "int", nullable: false),
                    Probability = table.Column<decimal>(type: "decimal(5,4)", nullable: false),
                    ExpectedQuantity = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    PredictedUseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModelVersion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GeneratedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSynthetic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourcePredictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourcePredictions_ResourceTypes_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResourcePredictions_SurgicalCases_SurgicalCaseId",
                        column: x => x.SurgicalCaseId,
                        principalTable: "SurgicalCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceUseEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurgicalCaseId = table.Column<int>(type: "int", nullable: false),
                    ResourceTypeId = table.Column<int>(type: "int", nullable: false),
                    UsedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantityUsed = table.Column<int>(type: "int", nullable: false),
                    BecameUnavailableAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SentToProcessingAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcessingStartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcessingCompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AvailableAgainAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalTurnaroundMinutes = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsSynthetic = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceUseEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceUseEvents_ResourceTypes_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResourceUseEvents_SurgicalCases_SurgicalCaseId",
                        column: x => x.SurgicalCaseId,
                        principalTable: "SurgicalCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurgicalCases_CaseNumber",
                table: "SurgicalCases",
                column: "CaseNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurgicalCases_Location",
                table: "SurgicalCases",
                column: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_SurgicalCases_ScheduledStart",
                table: "SurgicalCases",
                column: "ScheduledStart");

            migrationBuilder.CreateIndex(
                name: "IX_SurgicalCases_Service",
                table: "SurgicalCases",
                column: "Service");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceInventories_ResourceTypeId_Location",
                table: "ResourceInventories",
                columns: new[] { "ResourceTypeId", "Location" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePredictions_PredictedUseTime",
                table: "ResourcePredictions",
                column: "PredictedUseTime");

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePredictions_ResourceTypeId_PredictedUseTime",
                table: "ResourcePredictions",
                columns: new[] { "ResourceTypeId", "PredictedUseTime" });

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePredictions_SurgicalCaseId",
                table: "ResourcePredictions",
                column: "SurgicalCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceTypes_Name_Variant",
                table: "ResourceTypes",
                columns: new[] { "Name", "Variant" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUseEvents_ResourceTypeId_AvailableAgainAt",
                table: "ResourceUseEvents",
                columns: new[] { "ResourceTypeId", "AvailableAgainAt" });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUseEvents_ResourceTypeId_UsedAt",
                table: "ResourceUseEvents",
                columns: new[] { "ResourceTypeId", "UsedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUseEvents_SurgicalCaseId",
                table: "ResourceUseEvents",
                column: "SurgicalCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUseEvents_UsedAt",
                table: "ResourceUseEvents",
                column: "UsedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceInventories");

            migrationBuilder.DropTable(
                name: "ResourcePredictions");

            migrationBuilder.DropTable(
                name: "ResourceUseEvents");

            migrationBuilder.DropTable(
                name: "ResourceTypes");

            migrationBuilder.DropIndex(
                name: "IX_SurgicalCases_CaseNumber",
                table: "SurgicalCases");

            migrationBuilder.DropIndex(
                name: "IX_SurgicalCases_Location",
                table: "SurgicalCases");

            migrationBuilder.DropIndex(
                name: "IX_SurgicalCases_ScheduledStart",
                table: "SurgicalCases");

            migrationBuilder.DropIndex(
                name: "IX_SurgicalCases_Service",
                table: "SurgicalCases");

            migrationBuilder.DropColumn(
                name: "ActualDurationMinutes",
                table: "SurgicalCases");

            migrationBuilder.DropColumn(
                name: "ActualEnd",
                table: "SurgicalCases");

            migrationBuilder.DropColumn(
                name: "ActualStart",
                table: "SurgicalCases");

            migrationBuilder.DropColumn(
                name: "IsSynthetic",
                table: "SurgicalCases");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "SurgicalCases");

            migrationBuilder.DropColumn(
                name: "ProcedureCodeSystem",
                table: "SurgicalCases");

            migrationBuilder.DropColumn(
                name: "ScheduledDurationMinutes",
                table: "SurgicalCases");
				
			migrationBuilder.DropColumn(
				name: "Service",
				table: "SurgicalCases");

			migrationBuilder.DropColumn(
				name: "ProcedureCode",
				table: "SurgicalCases");

			migrationBuilder.AddColumn<string>(
				name: "SurgeonName",
				table: "SurgicalCases",
				type: "nvarchar(100)",
				maxLength: 100,
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<string>(
				name: "CrnaName",
				table: "SurgicalCases",
				type: "nvarchar(100)",
				maxLength: 100,
				nullable: false,
				defaultValue: "");

            migrationBuilder.RenameColumn(
                name: "ScheduledStart",
                table: "SurgicalCases",
                newName: "SurgeryDate");

            migrationBuilder.AddColumn<string>(
                name: "AnesTechName",
                table: "SurgicalCases",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnesthesiologistName",
                table: "SurgicalCases",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "SurgicalCases",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
