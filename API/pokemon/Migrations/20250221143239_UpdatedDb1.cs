using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokemon.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PokemonRegions",
                table: "PokemonRegions");

            migrationBuilder.AddColumn<int>(
                name: "TrainerID",
                table: "PokemonData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MoveName",
                table: "Moves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PokemonID",
                table: "Evolutions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokemonRegions",
                table: "PokemonRegions",
                columns: new[] { "PokemonID", "RegionID", "TrainerID" });

            migrationBuilder.CreateTable(
                name: "TypeLists",
                columns: table => new
                {
                    TypeListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeLists", x => x.TypeListID);
                });

            migrationBuilder.CreateTable(
                name: "PokemonTypes",
                columns: table => new
                {
                    PokemonID = table.Column<int>(type: "int", nullable: false),
                    TypeListID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTypes", x => new { x.PokemonID, x.TypeListID });
                    table.ForeignKey(
                        name: "FK_PokemonTypes_PokemonData_PokemonID",
                        column: x => x.PokemonID,
                        principalTable: "PokemonData",
                        principalColumn: "PokemonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonTypes_TypeLists_TypeListID",
                        column: x => x.TypeListID,
                        principalTable: "TypeLists",
                        principalColumn: "TypeListID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonData_TrainerID",
                table: "PokemonData",
                column: "TrainerID");

            migrationBuilder.CreateIndex(
                name: "IX_Evolutions_PokemonID",
                table: "Evolutions",
                column: "PokemonID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTypes_TypeListID",
                table: "PokemonTypes",
                column: "TypeListID");

            migrationBuilder.AddForeignKey(
                name: "FK_Evolutions_PokemonData_PokemonID",
                table: "Evolutions",
                column: "PokemonID",
                principalTable: "PokemonData",
                principalColumn: "PokemonID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonData_Trainers_TrainerID",
                table: "PokemonData",
                column: "TrainerID",
                principalTable: "Trainers",
                principalColumn: "TrainerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evolutions_PokemonData_PokemonID",
                table: "Evolutions");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonData_Trainers_TrainerID",
                table: "PokemonData");

            migrationBuilder.DropTable(
                name: "PokemonTypes");

            migrationBuilder.DropTable(
                name: "TypeLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokemonRegions",
                table: "PokemonRegions");

            migrationBuilder.DropIndex(
                name: "IX_PokemonData_TrainerID",
                table: "PokemonData");

            migrationBuilder.DropIndex(
                name: "IX_Evolutions_PokemonID",
                table: "Evolutions");

            migrationBuilder.DropColumn(
                name: "TrainerID",
                table: "PokemonData");

            migrationBuilder.DropColumn(
                name: "MoveName",
                table: "Moves");

            migrationBuilder.DropColumn(
                name: "PokemonID",
                table: "Evolutions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokemonRegions",
                table: "PokemonRegions",
                column: "PokemonID");
        }
    }
}
