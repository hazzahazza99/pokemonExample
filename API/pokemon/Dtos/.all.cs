//using Pokemon.Dtos;
//using System.ComponentModel.DataAnnotations;

//public class PokemonFullDto
//{
//    public int PokemonID { get; set; }

//    [Required]
//    public string PokemonName { get; set; }

//    public int? PokemonPictureID { get; set; }
//    public int? PokemonTrainerID { get; set; }
//    public int? EvolutionGroupID { get; set; }

//    public PictureDto? PokemonPicture { get; set; }

//    public TrainerDto? Trainer { get; set; }

//    public List<PokeTypeDto> Types { get; set; } = new();

//    public List<MoveDto> Moves { get; set; } = new();

//    public List<RegionDto> Regions { get; set; } = new();

//    public EvolutionGroupDto? EvolutionGroup { get; set; }
//    public List<EvolutionStageDto> EvolutionStages { get; set; } = new();
//}

//public class EvolutionGroupDto
//{
//    public int EvolutionGroupID { get; set; }
//}

//public class EvolutionStageDto
//{
//    public int GroupID { get; set; }
//    public int StageOrder { get; set; }
//    public int PokemonID { get; set; }
//}

//public class MoveDto
//{
//    public int MoveID { get; set; }
//    [Required]
//    [StringLength(50)]
//    public string MoveName { get; set; } = string.Empty;
//    [Range(10, 250)]
//    public int MovePower { get; set; }
//    [Range(1, 40)]
//    public int MovePP { get; set; }
//    [Required]
//    public int MovePokeTypeID { get; set; }
//    public PokeTypeDto? MovePokeType { get; set; }
//}
//public class MovesetDto
//{
//    public int MovesetPokemonID { get; set; }
//    public int MovesetMoveID { get; set; }
//}

//public class PictureDto
//{
//    public int PictureID { get; set; }
//    public string PicturePath { get; set; }
//}



//    public class PokemonDto
//    {
//        public int PokemonID { get; set; }
//        public string PokemonName { get; set; }
//        public int PokemonPictureID { get; set; }
//        public int? EvolutionGroupID { get; set; }
//        public int? PokemonTrainerID { get; set; }
//    }

//public class PokemonRegionDto
//{
//    public int RegionsPokemonID { get; set; }
//    public int RegionsRegionID { get; set; }
//}
//public class PokemonTypeDto
//{
//    public int TypesPokemonID { get; set; }
//    public int TypesPokeTypeID { get; set; }

//}

//public class PokeTypeDto
//{
//    public int PokeTypeID { get; set; }
//    [Required]
//    public string TypeName { get; set; } = string.Empty;
//}

//public class RegionDto
//{
//    public int RegionID { get; set; }
//    public string RegionName { get; set; }
//    public string RegionDescription { get; set; }
//}

//public class TrainerDto
//{
//    public int TrainerID { get; set; }
//    public required string TrainerName { get; set; }
//    public int TrainerAge { get; set; }
//    public int TrainerBadge { get; set; }
//    public bool TrainerIsGymLeader { get; set; }
//    public int? TrainerPhotoID { get; set; }
//}
