using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokemon.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                name: "Pictures",
                columns: table => new
                {
                    PictureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PicturePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PictureID);
                });

            migrationBuilder.CreateTable(
                name: "PokeTypes",
                columns: table => new
                {
                    PokeTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokeTypes", x => x.PokeTypeID);
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
                    TrainerAge = table.Column<int>(type: "int", nullable: false),
                    TrainerBadge = table.Column<int>(type: "int", nullable: false),
                    TrainerIsGymLeader = table.Column<bool>(type: "bit", nullable: false),
                    TrainerPhotoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.TrainerID);
                    table.ForeignKey(
                        name: "FK_Trainers_Pictures_TrainerPhotoID",
                        column: x => x.TrainerPhotoID,
                        principalTable: "Pictures",
                        principalColumn: "PictureID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    MoveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoveName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovePower = table.Column<int>(type: "int", nullable: false),
                    MovePP = table.Column<int>(type: "int", nullable: false),
                    MovePokeTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.MoveID);
                    table.ForeignKey(
                        name: "FK_Moves_PokeTypes_MovePokeTypeID",
                        column: x => x.MovePokeTypeID,
                        principalTable: "PokeTypes",
                        principalColumn: "PokeTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    PokemonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PokemonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PokemonPictureID = table.Column<int>(type: "int", nullable: false),
                    EvolutionGroupID = table.Column<int>(type: "int", nullable: true),
                    PokemonTrainerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.PokemonID);
                    table.ForeignKey(
                        name: "FK_Pokemon_EvolutionGroups_EvolutionGroupID",
                        column: x => x.EvolutionGroupID,
                        principalTable: "EvolutionGroups",
                        principalColumn: "EvolutionGroupID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pokemon_Pictures_PokemonPictureID",
                        column: x => x.PokemonPictureID,
                        principalTable: "Pictures",
                        principalColumn: "PictureID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pokemon_Trainers_PokemonTrainerID",
                        column: x => x.PokemonTrainerID,
                        principalTable: "Trainers",
                        principalColumn: "TrainerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EvolutionStages",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    StageOrder = table.Column<int>(type: "int", nullable: false),
                    PokemonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvolutionStages", x => new { x.GroupID, x.StageOrder });
                    table.ForeignKey(
                        name: "FK_EvolutionStages_EvolutionGroups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "EvolutionGroups",
                        principalColumn: "EvolutionGroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvolutionStages_Pokemon_PokemonID",
                        column: x => x.PokemonID,
                        principalTable: "Pokemon",
                        principalColumn: "PokemonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movesets",
                columns: table => new
                {
                    MovesetPokemonID = table.Column<int>(type: "int", nullable: false),
                    MovesetMoveID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movesets", x => new { x.MovesetPokemonID, x.MovesetMoveID });
                    table.ForeignKey(
                        name: "FK_Movesets_Moves_MovesetMoveID",
                        column: x => x.MovesetMoveID,
                        principalTable: "Moves",
                        principalColumn: "MoveID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movesets_Pokemon_MovesetPokemonID",
                        column: x => x.MovesetPokemonID,
                        principalTable: "Pokemon",
                        principalColumn: "PokemonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PokemonRegions",
                columns: table => new
                {
                    RegionsPokemonID = table.Column<int>(type: "int", nullable: false),
                    RegionsRegionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonRegions", x => new { x.RegionsPokemonID, x.RegionsRegionID });
                    table.ForeignKey(
                        name: "FK_PokemonRegions_Pokemon_RegionsPokemonID",
                        column: x => x.RegionsPokemonID,
                        principalTable: "Pokemon",
                        principalColumn: "PokemonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PokemonRegions_Regions_RegionsRegionID",
                        column: x => x.RegionsRegionID,
                        principalTable: "Regions",
                        principalColumn: "RegionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PokemonTypes",
                columns: table => new
                {
                    TypesPokemonID = table.Column<int>(type: "int", nullable: false),
                    TypesPokeTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTypes", x => new { x.TypesPokemonID, x.TypesPokeTypeID });
                    table.ForeignKey(
                        name: "FK_PokemonTypes_PokeTypes_TypesPokeTypeID",
                        column: x => x.TypesPokeTypeID,
                        principalTable: "PokeTypes",
                        principalColumn: "PokeTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PokemonTypes_Pokemon_TypesPokemonID",
                        column: x => x.TypesPokemonID,
                        principalTable: "Pokemon",
                        principalColumn: "PokemonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvolutionStages_PokemonID",
                table: "EvolutionStages",
                column: "PokemonID");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_MovePokeTypeID",
                table: "Moves",
                column: "MovePokeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Movesets_MovesetMoveID",
                table: "Movesets",
                column: "MovesetMoveID");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_EvolutionGroupID",
                table: "Pokemon",
                column: "EvolutionGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_PokemonPictureID",
                table: "Pokemon",
                column: "PokemonPictureID");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_PokemonTrainerID",
                table: "Pokemon",
                column: "PokemonTrainerID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonRegions_RegionsRegionID",
                table: "PokemonRegions",
                column: "RegionsRegionID");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTypes_TypesPokeTypeID",
                table: "PokemonTypes",
                column: "TypesPokeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_TrainerPhotoID",
                table: "Trainers",
                column: "TrainerPhotoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvolutionStages");

            migrationBuilder.DropTable(
                name: "Movesets");

            migrationBuilder.DropTable(
                name: "PokemonRegions");

            migrationBuilder.DropTable(
                name: "PokemonTypes");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Pokemon");

            migrationBuilder.DropTable(
                name: "PokeTypes");

            migrationBuilder.DropTable(
                name: "EvolutionGroups");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Pictures");
        }
    }
}
