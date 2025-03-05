import { EvolutionGroup } from "./evolution-group.model";
import { EvolutionStage } from "./evolution-stage.model";
import { Move } from "./move.model";
import { Picture } from "./picture.model";
import { PokemonType } from "./pokemon-type.model";
import { Region } from "./region.model";
import { Trainer } from "./trainer.model";

export interface Pokemon {
  pokemonID: number;
  pokemonName: string;
  pokemonPictureID: number | null;
  pokemonTrainerID: number | null;
  evolutionGroupID: number | null;
  pokemonPicture: Picture | null;
  trainer?: Trainer | null;
  types: PokemonType[];
  moves: Move[];
  regions: Region[];
  evolutionGroup: EvolutionGroup | null;
  evolutionStages: EvolutionStage[];
}

export interface PokemonFullDto {
  pokemonID?: number;
  pokemonName: string;
  pokemonPictureID?: number | null;
  pokemonTrainerID?: number | null;
  evolutionGroupID?: number | null;
  types: PokeTypeDto[];
  moves: MoveDto[];
  regions: RegionDto[];
  evolutionStages: EvolutionStageDto[];
}

export interface PokeTypeDto {
  pokeTypeID: number;
  typeName: string;
}

export interface MoveDto {
  moveID: number;
  moveName: string;
  movePP: number;
  movePower: number;
}

export interface RegionDto {
  regionID: number;
  regionName: string;
  regionDescription: string;
}

export interface EvolutionStageDto {
  groupID: number;
  stageOrder: number;
  pokemonID?: number;
}

export interface PokemonRequest {
  pokemonDto: PokemonFullDto;
}