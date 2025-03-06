export interface PokemonUpdateDto {
    pokemonID?: number;
    pokemonName?: string;
    pokemonPictureID?: number | null;
    pokemonTrainerID?: number | null;
    evolutionGroupID?: number | null;
    pokemonPicture?: PictureDto | null;
    trainer?: TrainerDto | null;
    types?: PokeTypeDto[];
    moves?: MoveDto[];
    regions?: RegionDto[];
    evolutionGroup?: EvolutionGroupDto | null;
    evolutionStages?: EvolutionStageDto[];
  }
  
  export interface PictureDto {
    pictureID?: number;
    picturePath?: string;
  }
  
  export interface TrainerDto {
    trainerID?: number;
    trainerName?: string;
    trainerAge?: number;
    trainerBadge?: number;
    trainerIsGymLeader?: boolean;
    trainerPhotoID?: number | null;
  }
  
  export interface EvolutionGroupDto {
    evolutionGroupID?: number;
  }

  export interface PokeTypeDto{
    pokeTypeID?: number;
    typeName?: string;
  }

  export interface MoveDto{
    moveID?: number;
    moveName?: string;
    movePower?: number;
    movePP?: number;
    movePokeTypeID?: number;
  }
  export interface RegionDto{
    regionID?: number;
    regionName?: string;
    regionDescription?: string;
  }
  export interface EvolutionStageDto{
    groupID?: number;
    stageOrder?: number;
    pokemonID?: number;
  }