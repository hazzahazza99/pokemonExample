import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Pokemon,  } from '../models/pokemon.model';
import { PokemonGridService } from '../services/pokemon-grid.service';
import { confirm } from 'devextreme/ui/dialog';
import { DxDataGridTypes } from 'devextreme-angular/ui/data-grid';
import { PokemonTypeService } from '../services/types-list.service';
import { PokemonMoveService } from '../services/moves-grid.service';
import { PokemonType } from '../models/pokemon-type.model';
import { Move } from '../models/move.model';
import { Region } from '../models/region.model';
import { RegionsService } from '../services/regions.service';
import { environment } from '../env/environment';
import { TrainerGridService } from '../services/trainer-grid.service';
import { Trainer } from '../models/trainer.model';

@Component({
  selector: 'app-pokemon-grid',
  templateUrl: './pokemon-grid.component.html',
  styleUrls: ['./pokemon-grid.component.scss']
})

export class PokemonGridComponent implements OnInit {
  baseUrl = environment.baseUrl
  isDrawerOpen = false;
  selectedPokemon: Pokemon | null = null;
  pokemonList$ = new BehaviorSubject<Pokemon[]>([]);
  types$ = new BehaviorSubject<PokemonType[]>([]);
  moves$ = new BehaviorSubject<Move[]>([]);
  regions$ = new BehaviorSubject<Region[]>([]);
  trainers$ = new BehaviorSubject<Trainer[]>([]);
  types: PokemonType[] =[];
  moves: Move[] = []; 
  regions: Region[] =[];
  trainers: Trainer[] =[];
  isNewPokemon = false;


  constructor(
    private pgs: PokemonGridService, 
    private typeserv: PokemonTypeService,
    private moveserv: PokemonMoveService,
    private regserv: RegionsService,
    private trs: TrainerGridService,
  ) {}

  ngOnInit(): void {
    this.loadPokemon();
    this.loadTypes();
    this.loadMoves();
    this.loadRegions();
    this.loadTrainers();
  }

  private loadPokemon() {
    this.pgs.getAllPokemon().subscribe({
      next: (data) => {
        this.pokemonList$.next(data);       
      },
      error: (err) => console.error('Error loading Pokémon:', err)
    });
  }

  private loadTypes() {
    this.typeserv.getAllTypes().subscribe({
      next: (data) => {
        this.types = data.map(t => ({
          pokeTypeID: t.pokeTypeID,
          typeName: t.typeName,
        }));
        this.types$.next(this.types);
      }
    });
  }
  
  private loadMoves() {
    this.moveserv.getAllMoves().subscribe({
      next: (data) => {
        this.moves = data.map(m => ({
          moveID: m.moveID,
          moveName: m.moveName,
          movePower: m.movePower,
          movePP: m.movePP,
          movePokeTypeID: m.movePokeTypeID,
          movePokeType: this.types.find(t => t.pokeTypeID === m.movePokeTypeID) || null
        }));
        this.moves$.next(this.moves);
      }
    });
  }
  
  private loadRegions() {
    this.regserv.getAllRegions().subscribe({
      next: (data) => {
        this.regions = data.map(r => ({
          regionID: r.regionID,
          regionName: r.regionName,
          regionDescription: r.regionDescription
        }));
        this.regions$.next(this.regions);
      }
    });
  }

  private loadTrainers() {
    this.trs.getAllTrainers().subscribe({
      next: (data) => {
        this.trainers$.next(data);  
        this.trainers = data;       
      },
      error: (err) => console.error('Error loading Pokemon:', err)
    });
  }

  private prepareSelectedPokemon(pokemon: Pokemon): Pokemon {
    const selectedPokemon = { ...pokemon };
    selectedPokemon.types = pokemon.types.map(type => this.types.find(t => t.pokeTypeID === type.pokeTypeID)!);
    selectedPokemon.moves = pokemon.moves.map(move => this.moves.find(m => m.moveID === move.moveID)!);
    selectedPokemon.regions = pokemon.regions.map(regions => this.regions.find(m => m.regionID === regions.regionID)!);
    selectedPokemon.pokemonTrainerID = pokemon.trainer?.trainerID || null;
    return selectedPokemon;
  }

  private initializeNewPokemon(): Pokemon {
    return {
      pokemonID: 0,
      pokemonName: '',
      pokemonPictureID: null,
      pokemonTrainerID: null,
      evolutionGroupID: null,
      pokemonPicture: null,
      trainer: null,
      types: [],
      moves: [],
      regions: [],
      evolutionGroup: null,
      evolutionStages: []
    };
  }

  async deletePokemon(e: any) {
    if (!e.row.data.pokemonID) {
      console.error("Invalid event data:", e);
      return;
  }
    const pokemonId = e.row.data.pokemonID;
    console.log("attempting delete ",pokemonId)
    const result = await confirm('Are you sure?', 'Delete Pokémon');
    if (result) {
      this.pgs.deletePokemon(pokemonId).subscribe({
        next: () => this.loadPokemon(),
        error: (err) => console.error('Delete failed:', err)
      });
    }
  }

  openDrawer(pokemon?: Pokemon) {
    this.isNewPokemon = !pokemon;
    this.selectedPokemon = pokemon ? this.prepareSelectedPokemon(pokemon) : this.initializeNewPokemon();
    this.isDrawerOpen = true;
    console.log(this.selectedPokemon)
  }

  saveChanges() {  
    const dto = (this.selectedPokemon!);

    if (this.isNewPokemon) {
      this.pgs.createPokemon(dto).subscribe({
        next: () => {
          this.loadPokemon();
          this.closeDrawer();
        },
        error: (err) => console.error('Create failed:', err)
      });
    } else {
      this.pgs.updatePokemon(dto.pokemonID!, dto).subscribe({
        next: () => {
          this.loadPokemon();
          this.closeDrawer();
        },
        error: (err) => console.error('Update failed:', err)
      });
    }
  }


  closeDrawer() {
    this.isDrawerOpen = false;
    this.selectedPokemon = null;
    this.isNewPokemon = false;
  }

  handleDrawerClose(event: any) {
    if (event.name === 'opened' && !event.value) {
      this.closeDrawer();
    }
  }

  validateMoveSelection(e: any) {
    const selectedMoves = e.value;
    return selectedMoves && selectedMoves.length >= 1 && selectedMoves.length <= 4;
  }

  validateTypeSelection(e: any) {
    const selectedTypes = e.value;
    return selectedTypes && selectedTypes.length >= 1 && selectedTypes.length <= 2;
  }


  getTrainerName(rowData: Pokemon): string {
    return rowData?.trainer?.trainerName || 'Wild Pokemon';
  }

  getTypesName(rowData: Pokemon): string {
    return rowData.types?.length 
      ? rowData.types.map(t => t?.typeName || 'Unknown').join(', ') 
      : 'No Types Assigned';
  }
  
  getMovesName(rowData: Pokemon): string {
    return rowData.moves?.length 
      ? rowData.moves.map(m => m.moveName).join(', ') 
      : 'No Moves Assigned';
  }
  
  getRegionsName(rowData: Pokemon): string {
    return rowData.regions?.length 
      ? rowData.regions.map(r => r.regionName).join(', ') 
      : 'No Regions Assigned';
  }
  
  getEvolutionStageID(rowData: Pokemon): string {
    return rowData.evolutionStages?.length 
      ? rowData.evolutionStages.map(s => s.stageOrder).join(', ') 
      : '1';
  }
}
