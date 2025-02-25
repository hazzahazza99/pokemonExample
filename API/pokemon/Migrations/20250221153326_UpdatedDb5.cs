using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokemon.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDb5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonRegions_Trainers_TrainerID",
                table: "PokemonRegions");

            migrationBuilder.DropIndex(
                name: "IX_PokemonRegions_TrainerID",
                table: "PokemonRegions");

            migrationBuilder.DropColumn(
                name: "TrainerID",
                table: "PokemonRegions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainerID",
                table: "PokemonRegions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PokemonRegions_TrainerID",
                table: "PokemonRegions",
                column: "TrainerID");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonRegions_Trainers_TrainerID",
                table: "PokemonRegions",
                column: "TrainerID",
                principalTable: "Trainers",
                principalColumn: "TrainerID");
        }
    }
}
