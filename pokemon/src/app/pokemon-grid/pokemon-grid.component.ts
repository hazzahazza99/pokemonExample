import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Pokemon } from '../models/pokemon.model';
import { PokemonGridService } from '../services/pokemon-grid.service';
import { confirm } from 'devextreme/ui/dialog';
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
  baseUrl = environment.baseUrl;
  isDrawerOpen = false;
  selectedPokemon: Pokemon | null = null;
  pokemonList$ = new BehaviorSubject<Pokemon[]>([]);
  types$ = new BehaviorSubject<PokemonType[]>([]);
  moves$ = new BehaviorSubject<Move[]>([]);
  regions$ = new BehaviorSubject<Region[]>([]);
  trainers$ = new BehaviorSubject<Trainer[]>([]);
  types: PokemonType[] = [];
  moves: Move[] = []; 
  regions: Region[] = [];
  trainers: Trainer[] = [];
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
      next: (data) => this.pokemonList$.next(data),
      error: (err) => console.error('Error loading Pokémon:', err)
    });
  }

  private loadTypes() {
    this.typeserv.getAllTypes().subscribe({
      next: (data) => {
        this.types = data;
        this.types$.next(this.types);
      }
    });
  }
  
  private loadMoves() {
    this.moveserv.getAllMoves().subscribe({
      next: (data) => {
        this.moves = data;
        this.moves$.next(this.moves);
      }
    });
  }
  
  private loadRegions() {
    this.regserv.getAllRegions().subscribe({
      next: (data) => {
        this.regions = data;
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
      error: (err) => console.error('Error loading Trainers:', err)
    });
  }

  private prepareSelectedPokemon(pokemon: Pokemon): Pokemon {
    const selectedPokemon = { ...pokemon };
    selectedPokemon.types = pokemon.types.map(type => this.types.find(t => t.pokeTypeID === type.pokeTypeID)!);
    selectedPokemon.moves = pokemon.moves.map(move => this.moves.find(m => m.moveID === move.moveID)!);
    selectedPokemon.regions = pokemon.regions.map(regions => this.regions.find(m => m.regionID === regions.regionID)!);
    return selectedPokemon;
  }

  private initializeNewPokemon(): Pokemon {
    return {
      pokemonID: 0,
      pokemonName: '',
      types: [],
      moves: [],
      regions: [],
    };
  }

  async deletePokemon(e: any) {
    const pokemonId = e.row.data.pokemonID;
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
  }

  saveChanges() {  
    const dto = this.selectedPokemon!;
    const operation = this.isNewPokemon 
      ? this.pgs.createPokemon(dto) 
      : this.pgs.updatePokemon(dto.pokemonID!, dto);

    operation.subscribe({
      next: () => {
        this.loadPokemon();
        this.closeDrawer();
      },
      error: (err) => console.error(this.isNewPokemon ? 'Create failed:' : 'Update failed:', err)
    });
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

  validateTypeSelection(e: any) {
    const selectedTypes = e.value;
    return selectedTypes?.length >= 1 && selectedTypes.length <= 2;
  }

  getTrainerName(rowData: Pokemon): string {
    return rowData?.trainer?.trainerName || 'Wild Pokemon';
  }

  getTypesName(rowData: Pokemon): string {
    return rowData.types?.map(t => t?.typeName).join(', ') || 'No Types Assigned';
  }
  
  getMovesName(rowData: Pokemon): string {
    return rowData.moves?.map(m => m.moveName).join(', ') || 'No Moves Assigned';
  }
  
  getRegionsName(rowData: Pokemon): string {
    return rowData.regions?.map(r => r.regionName).join(', ') || 'No Regions Assigned';
  }
  
  getEvolutionStageID(rowData: Pokemon): string {
    return rowData.evolutionStages?.map(s => s.stageOrder).join(', ') || '1';
  }
}