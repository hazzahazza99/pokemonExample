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

export interface UpdatePokemon {
  pokemonName: string;
  types: PokemonType[];
  moves: Move[];
  regions: Region[];
  evolutionGroup?: EvolutionGroup | null;
  trainer?: Trainer | null;
  pokemonPicture?: Picture | null;
}
