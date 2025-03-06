using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokemon.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEvolutionStages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EvolutionStages_GroupID_StageOrder",
                table: "EvolutionStages",
                columns: new[] { "GroupID", "StageOrder" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EvolutionStages_GroupID_StageOrder",
                table: "EvolutionStages");
        }
    }
}
