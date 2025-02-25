using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokemon.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvolutionGroups",
                columns: table => new
                {
                    EvolutionGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvolutionGroups", x => x.EvolutionGroupID);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    MoveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovePP = table.Column<int>(type: "int", nullable: false),
                    MovePower = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.MoveID);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PictureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PictureID);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionID);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    TrainerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainerAge = table.Column<int>(type: "int", nullable: true),
                    TrainerBadge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsGymLeader = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.TrainerID);
                });

            migrationBuilder.CreateTable(
                name: "Evolutions",
                columns: table => new
                {
                    EvolutionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageNumber = table.Column<int>(type: "int", nullable: false),
                    EvolutionGroupID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evolutions", x => x.EvolutionID);
                    table.ForeignKey(
                        name: "FK_Evolutions_EvolutionGroups_EvolutionGroupID",
                        column: x => x.EvolutionGroupID,
                        principalTable: "EvolutionGroups",
                        principalColumn: "EvolutionGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonData",
                columns: table => new
                {
                    PokemonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PokemonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureID = table.Column<int>(type: "int", nullable: true),
                    EvolutionGroupID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonData", x => x.PokemonID);
                    table.ForeignKey(
                        name: "FK_PokemonData_EvolutionGroups_EvolutionGroupID",
                        column: x => x.EvolutionGroupID,
                        principalTable: "EvolutionGroups",
                        principalColumn: "EvolutionGroupID");
                    table.ForeignKey(
                        name: "FK_PokemonData_Pictures_PictureID",
                        column: x => x.PictureID,
                        principalTable: "Pictures",
                        principalColumn: "PictureID");
                });

            migrationBuilder.CreateTable(
                name: "Movesets",
                columns: table => new
                {
                    PokemonID = table.Column<int>(type: "int", nullable: false),
                    MoveID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movesets", x => new { x.PokemonID, x.MoveID });
                    table.ForeignKey(
                        name: "FK_Movesets_Moves_MoveID",
                        column: x => x.MoveID,
                        principalTable: "Moves",
                        principalColumn: "MoveID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movesets_PokemonData_PokemonID",
                        column: x => x.PokemonID,
                        principalTable: "PokemonData",
                        principalColumn: "PokemonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonRegions",
                columns: table => new
                {
                    PokemonID = table.Column<int>(type: "int", nullable: false),
                    RegionID = table.Column<int>(type: "int", nullable: false),
                    TrainerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonRegions", x => x.PokemonID);
                    table.ForeignKey(
                        name: "FK_PokemonRegions_PokemonData_PokemonID",
                        column: x => x.PokemonID,
                        principalTable: "PokemonData",
                        principalColumn: "PokemonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonRegions_Regions_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Regions",
                        principalColumn: "RegionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonRegions_Trainers_TrainerID",
                        column: x => x.TrainerID,
                        principalTable: "Trainers",
                        principalColumn: "TrainerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evolutions_EvolutionGroupID",
                table: "Evolutions",
                column: "EvolutionGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Movesets_MoveID",
                table: "Movesets",
                column: "MoveID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonData_EvolutionGroupID",
                table: "PokemonData",
                column: "EvolutionGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonData_PictureID",
                table: "PokemonData",
                column: "PictureID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonRegions_RegionID",
                table: "PokemonRegions",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonRegions_TrainerID",
                table: "PokemonRegions",
                column: "TrainerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evolutions");

            migrationBuilder.DropTable(
                name: "Movesets");

            migrationBuilder.DropTable(
                name: "PokemonRegions");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "PokemonData");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "EvolutionGroups");

            migrationBuilder.DropTable(
                name: "Pictures");
        }
    }
}
