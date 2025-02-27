export interface Pokemon {
  pokemonID: number;
  pokemonName: string;
  types: string[];
  moves: string[];
  regions: string[];
  evolutionGroup?: EvolutionGroup;
  trainer?: Trainer;
  pokemonPicture: Picture;
}

export interface UpdatePokemon {
  pokemonName: string;
  types: string[];
  moves: string[];
  regions: string[];
  evolutionGroup?: EvolutionGroup | null;  
  trainer?: Trainer | null;               
  pokemonPicture?: Picture;
}

interface EvolutionGroup {
  groupID: number;
  evolutionStages: EvolutionStage[];
}

interface EvolutionStage {
  stageOrder: number;
  pokemon: SimplePokemon;
}

interface SimplePokemon {
  pokemonID: number;
  pokemonName: string;
}

interface Trainer {
  trainerID: number;
  trainerName: string;
}

interface Picture {
  pictureID: number;
  picturePath: string;
}