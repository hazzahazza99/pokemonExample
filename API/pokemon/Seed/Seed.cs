using Microsoft.EntityFrameworkCore;
using Pokemon.Models;

namespace Pokemon.Data
{
    public static class Seed
    {
        public static async Task Initialize(DataContext context)
        {
            await context.Database.MigrateAsync();

            if (context.Pokemon.Any()) return;

            var pictures = new List<Picture>
            {
                new() { PicturePath = "images/pokemon/char.png" },
                new() { PicturePath = "images/pokemon/squi.png" },
                new() { PicturePath = "images/pokemon/bulb.png" },
                new() { PicturePath = "images/pokemon/pika.png" },
                new() { PicturePath = "images/pokemon/charmeleon.png" },
                new() { PicturePath = "images/trainers/brock.png" },
                new() { PicturePath = "images/trainers/ash.png" },
                new() { PicturePath = "images/trainers/misty.png" }
            };
            await context.Pictures.AddRangeAsync(pictures);
            await context.SaveChangesAsync();

            var trainers = new List<Trainer>
            {
                new() {
                    TrainerName = "Brock",
                    TrainerAge = 28,
                    TrainerBadge = 5,
                    TrainerIsGymLeader = true,
                    TrainerPhotoID = pictures[5].PictureID
                },
                new() {
                    TrainerName = "Ash",
                    TrainerAge = 15,
                    TrainerBadge = 1,
                    TrainerIsGymLeader = false,
                    TrainerPhotoID = pictures[6].PictureID
                },
                new() {
                    TrainerName = "Misty",
                    TrainerAge = 16,
                    TrainerBadge = 3,
                    TrainerIsGymLeader = false,
                    TrainerPhotoID = pictures[7].PictureID
                }
            };
            await context.Trainers.AddRangeAsync(trainers);
            await context.SaveChangesAsync();

            var types = new List<PokeType>
            {
                new() { TypeName = "Fire" },
                new() { TypeName = "Water" },
                new() { TypeName = "Grass" },
                new() { TypeName = "Poison" },
                new() { TypeName = "Electric" },
                new() { TypeName = "Normal" },
                new() { TypeName = "Fighting" },
                new() { TypeName = "Flying" },
                new() { TypeName = "Ground" },
                new() { TypeName = "Rock" },
                new() { TypeName = "Bug" },
                new() { TypeName = "Ghost" },
                new() { TypeName = "Steel" },
                new() { TypeName = "Psychic" },
                new() { TypeName = "Ice" },
                new() { TypeName = "Dragon" },
                new() { TypeName = "Fairy" },
                new() { TypeName = "Dark" }
            };
            await context.PokeTypes.AddRangeAsync(types);
            await context.SaveChangesAsync();

            var regions = new List<Region>
            {
                new() {
                    RegionName = "Kanto",
                    RegionDescription = "The starting region for many Pokémon trainers"
                },
                new() {
                    RegionName = "Johto",
                    RegionDescription = "A region known for its historic towers and legendary Pokémon"
                },
                new()
                {
                    RegionName = "Hoenn",
                    RegionDescription = "A region filled with vast seas and diverse environments"
                },
                new()
                {
                    RegionName = "Sinnoh",
                    RegionDescription = "A region with a rich mythology and snowy mountain peaks"
                },
                new()
                {
                    RegionName = "Unova",
                    RegionDescription = "A region inspired by New York, featuring big cities and bridges"
                },
                new()
                {
                    RegionName = "Kalos",
                    RegionDescription = "A region known for its beauty, fashion, and Mega Evolution"
                },
                new()
                {
                    RegionName = "Alola",
                    RegionDescription = "An island-themed region with unique regional Pokémon forms"
                },
                new()
                {
                    RegionName = "Galar",
                    RegionDescription = "A region inspired by the UK, featuring a major league battle system"
                },
                new()
                {
                    RegionName = "Paldea",
                    RegionDescription = "A region inspired by Spain, focusing on open-world exploration"
                }
            };
            await context.Regions.AddRangeAsync(regions);
            await context.SaveChangesAsync();

            var moves = new List<Move>
            {
                new() {
                    MoveName = "Ember",
                    MovePower = 35,
                    MovePP = 35,
                    MovePokeTypeID = types[0].PokeTypeID
                },
                new() {
                    MoveName = "Water Gun",
                    MovePower = 40,
                    MovePP = 25,
                    MovePokeTypeID = types[1].PokeTypeID
                },
                new() {
                    MoveName = "Vine Whip",
                    MovePower = 45,
                    MovePP = 20,
                    MovePokeTypeID = types[2].PokeTypeID
                },
                new() {
                    MoveName = "Thunder Shock",
                    MovePower = 40,
                    MovePP = 30,
                    MovePokeTypeID = types[4].PokeTypeID
                }
            };
            await context.Moves.AddRangeAsync(moves);
            await context.SaveChangesAsync();

            var pokemonList = new List<PokemonData>
            {
                new() {
                    PokemonName = "Charmander",
                    PokemonPictureID = pictures[0].PictureID,
                    PokemonTrainerID = trainers[0].TrainerID
                },
                new() {
                    PokemonName = "Squirtle",
                    PokemonPictureID = pictures[1].PictureID,
                    PokemonTrainerID = trainers[1].TrainerID
                },
                new() {
                    PokemonName = "Bulbasaur",
                    PokemonPictureID = pictures[2].PictureID,
                    PokemonTrainerID = trainers[2].TrainerID
                },
                new() {
                    PokemonName = "Pikachu",
                    PokemonPictureID = pictures[3].PictureID
                },
                new() {
                    PokemonName = "Charmeleon",
                    PokemonPictureID = pictures[4].PictureID,
                    PokemonTrainerID = trainers[0].TrainerID
                }
            };
            await context.Pokemon.AddRangeAsync(pokemonList);
            await context.SaveChangesAsync();

            var evolutionGroups = new List<EvolutionGroup>
            {
                new() { },  
                new() { },  
                new() { }   
            };
            await context.EvolutionGroups.AddRangeAsync(evolutionGroups);
            await context.SaveChangesAsync();

            var evolutionStages = new List<EvolutionStage>
            {
                new() {
                    GroupID = evolutionGroups[0].EvolutionGroupID,
                    StageOrder = 1,
                    PokemonID = pokemonList[2].PokemonID 
                },
                new() {
                    GroupID = evolutionGroups[1].EvolutionGroupID,
                    StageOrder = 1,
                    PokemonID = pokemonList[0].PokemonID  
                },
                new() {
                    GroupID = evolutionGroups[2].EvolutionGroupID,
                    StageOrder = 1,
                    PokemonID = pokemonList[3].PokemonID
                },
                new() {
                    GroupID = evolutionGroups[1].EvolutionGroupID,
                    StageOrder = 2,
                    PokemonID = pokemonList[4].PokemonID
                }
            };
            await context.EvolutionStages.AddRangeAsync(evolutionStages);
            await context.SaveChangesAsync();

            var pokemonTypes = new List<PokemonType>
            {
                new() { TypesPokemonID = pokemonList[0].PokemonID, TypesPokeTypeID = types[0].PokeTypeID },
                new() { TypesPokemonID = pokemonList[1].PokemonID, TypesPokeTypeID = types[1].PokeTypeID },
                new() { TypesPokemonID = pokemonList[2].PokemonID, TypesPokeTypeID = types[2].PokeTypeID },
                new() { TypesPokemonID = pokemonList[2].PokemonID, TypesPokeTypeID = types[3].PokeTypeID },
                new() { TypesPokemonID = pokemonList[3].PokemonID, TypesPokeTypeID = types[4].PokeTypeID },
                new() { TypesPokemonID = pokemonList[4].PokemonID, TypesPokeTypeID = types[0].PokeTypeID }
            };
            await context.PokemonTypes.AddRangeAsync(pokemonTypes);

            var pokemonRegions = new List<PokemonRegion>
            {
                new() { RegionsPokemonID = pokemonList[0].PokemonID, RegionsRegionID = regions[0].RegionID },
                new() { RegionsPokemonID = pokemonList[1].PokemonID, RegionsRegionID = regions[0].RegionID },
                new() { RegionsPokemonID = pokemonList[2].PokemonID, RegionsRegionID = regions[0].RegionID },
                new() { RegionsPokemonID = pokemonList[3].PokemonID, RegionsRegionID = regions[0].RegionID },
                new() { RegionsPokemonID = pokemonList[4].PokemonID, RegionsRegionID = regions[1].RegionID },
            };
            await context.PokemonRegions.AddRangeAsync(pokemonRegions);

            var movesets = new List<Moveset>
            {
                new() { MovesetPokemonID = pokemonList[0].PokemonID, MovesetMoveID = moves[0].MoveID },
                new() { MovesetPokemonID = pokemonList[1].PokemonID, MovesetMoveID = moves[1].MoveID },
                new() { MovesetPokemonID = pokemonList[2].PokemonID, MovesetMoveID = moves[2].MoveID },
                new() { MovesetPokemonID = pokemonList[3].PokemonID, MovesetMoveID = moves[3].MoveID },
                new() { MovesetPokemonID = pokemonList[4].PokemonID, MovesetMoveID = moves[0].MoveID }
            };
            await context.Movesets.AddRangeAsync(movesets);

            await context.SaveChangesAsync();
        }
    }
}