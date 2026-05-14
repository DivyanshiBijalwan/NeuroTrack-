using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeuroTrack.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReactionTime = table.Column<double>(type: "float", nullable: false),
                    MemoryScore = table.Column<double>(type: "float", nullable: false),
                    FocusScore = table.Column<double>(type: "float", nullable: false),
                    OverallScore = table.Column<double>(type: "float", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Badge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    XP = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResults", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "TestResults");
        }
    }
}
