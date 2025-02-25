import { Trainer } from "./trainer.model";

export interface Pokemon {
    pokemonID: number;
    pokemonName: string;
    trainerID?: number;
    pictureID?: number;
    pictureURL?: string;
    trainer?: Trainer;
    pokemonRegions?: PokemonRegion[];
    movesets?: Moveset[];
    evolutionGroup?: EvolutionGroup;
  }
  
  export interface UpdatePokemon {
    pokemonName: string;
    trainerID?: number;
    pictureID?: number;
    evolutionGroupID?: number;
  }
  
  export interface PokemonRegion {
    regionID: number;
    regionName: string;
  }
  
  export interface Moveset {
    moveID: number;
    moveName: string;
  }
  
  export interface EvolutionGroup {
    evolutionGroupID: number;
    evolutionGroupName: string;
  }
  