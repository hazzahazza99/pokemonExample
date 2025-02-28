export interface Pokemon {
  pokemonID: number;
  pokemonName: string;
  pokemonPictureID: number | null;
  pokemonTrainerID: number | null;
  evolutionGroupID: number | null;
  pokemonPicture: Picture | null;
  trainer: Trainer | null;
  types: PokemonType[];
  moves: Move[];
  regions: Region[];
  evolutionGroup: EvolutionGroup | null;
  evolutionStages: EvolutionStage[];
}

export interface UpdatePokemon {
  pokemonName: string;
  types: PokemonType[];
  moves: Move[];
  regions: Region[];
  evolutionGroup?: EvolutionGroup | null;
  trainer?: Trainer | null;
  pokemonPicture?: Picture | null;
}

export interface PokemonType {
  pokeTypeID: number;
  typeName: string;
}

export interface Move {
  moveID: number;
  moveName: string;
  movePower: number;
  movePP: number;
  movePokeTypeID: number;
}

export interface Region {
  regionID: number;
  regionName: string;
  regionDescription: string;
}

export interface EvolutionGroup {
  evolutionGroupID: number;
}

export interface EvolutionStage {
  groupID: number;
  stageOrder: number;
  pokemonID: number;
}

export interface Trainer {
  trainerID: number;
  trainerName: string;
  trainerAge: number;
  trainerBadge: number;
  trainerIsGymLeader: boolean;
  trainerPhotoID: number;
}

export interface Picture {
  pictureID: number;
  picturePath: string;
}
