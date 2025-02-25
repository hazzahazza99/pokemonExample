using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokemon.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDb4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonRegions_Trainers_TrainerID",
                table: "PokemonRegions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokemonRegions",
                table: "PokemonRegions");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerID",
                table: "PokemonRegions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokemonRegions",
                table: "PokemonRegions",
                columns: new[] { "PokemonID", "RegionID" });

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonRegions_Trainers_TrainerID",
                table: "PokemonRegions",
                column: "TrainerID",
                principalTable: "Trainers",
                principalColumn: "TrainerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonRegions_Trainers_TrainerID",
                table: "PokemonRegions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokemonRegions",
                table: "PokemonRegions");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerID",
                table: "PokemonRegions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokemonRegions",
                table: "PokemonRegions",
                columns: new[] { "PokemonID", "RegionID", "TrainerID" });

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonRegions_Trainers_TrainerID",
                table: "PokemonRegions",
                column: "TrainerID",
                principalTable: "Trainers",
                principalColumn: "TrainerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
