import { Move } from '../models/move.model';
import { Region } from '../models/region.model';
import { RegionsService } from '../services/regions.service';
import { environment } from '../env/environment';
import { TrainerGridService } from '../services/trainer-grid.service';
import { Trainer } from '../models/trainer.model';
import { EvolutionStage } from '../models/evolution-stage.model';
import { EvolutionStageService } from '../services/evolution-stage.service';

interface PokemonGridColumn extends DxDataGridTypes.Column {
  dataField: string;

@@ -24,16 +29,21 @@ interface PokemonGridColumn extends DxDataGridTypes.Column {
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
  evolutionStages$ = new BehaviorSubject<EvolutionStage[]>([]);
  pokemonList: Pokemon[] = []; 
  types: PokemonType[] =[];
  moves: Move[] = []; 
  regions: Region[] =[];
  regions: Region[] =[];
  trainers: Trainer[] =[];
  evolutionStages: EvolutionStage[] = [];
  isNewPokemon = false;

  columns: (string | PokemonGridColumn | DxDataGridTypes.Column)[] = [
    { 
      dataField: 'pokemonID', 
      caption: 'ID', 
      width: 100 
    },
    { 
      dataField: 'pokemonName', 
      caption: 'Pokemon Name' 
    },
    { 
      dataField: 'trainer.trainerName', 
      caption: 'Trainer',
      calculateCellValue: (rowData: { trainer?: { trainerName?: string } }) => 
        rowData.trainer?.trainerName || 'Wild Pokemon'
    },
    {
      dataField: 'types',
      caption: 'Types',
      calculateCellValue: (rowData: Pokemon) => {
        if(!rowData.types || rowData.types.length === 0) return "No Types Assigned";
        return rowData.types
        .map(types => `${types.typeName}`)
        .join(', ')
      }
    },
    {
      dataField: 'moves',
      caption: 'Moves',
      calculateCellValue: (rowData: Pokemon) => {
        if(!rowData.moves || rowData.moves.length === 0) return "No Moves Assigned";
        return rowData.moves
        .map(move => `${move.moveName}`)
        .join(', ')
        }
    },
    {
      dataField: 'regions',
      caption: 'Regions',
      calculateCellValue: (rowData: Pokemon) => {
        if(!rowData.regions || rowData.regions.length === 0) return "No Regions Assigned";
        return rowData.regions
        .map(regions => `${regions.regionName}`)
        .join(', ')
        }
    },
    {
      dataField: 'evolutionStages',
      caption: 'Evolution Stage',
      calculateCellValue: (rowData: Pokemon) => {
        if (!rowData.evolutionStages || rowData.evolutionStages.length === 0) return '1';   
        return rowData.evolutionStages
          .map(stage => `${stage.stageOrder}`)
          .join(', ');
      }
    },
    {
      dataField: 'pokemonPicture.picturePath',
      caption: 'Image',
      cellTemplate: 'imageTemplate'
    },
    {
      type: 'buttons',
      width: 100,
      buttons: [{
        text: 'Delete',
        onClick: async (e: DxDataGridTypes.ColumnButtonClickEvent) => {
          const pokemonId = e.row?.data.pokemonID;
          if (pokemonId) {
            await this.deletePokemon(pokemonId);
          }
        }
      }] as DxDataGridTypes.ColumnButton[]
    }
  ];

  constructor(
    private pgs: PokemonGridService, 
    private typeserv: PokemonTypeService,
    private moveserv: PokemonMoveService,
    private regserv: RegionsService,
    private trs: TrainerGridService,
    private ess: EvolutionStageService,
  ) {}

  ngOnInit(): void {
    this.loadPokemon();
    this.loadTypes();
    this.loadMoves();
    this.loadRegions();
    this.loadTrainers();
    this.loadEvolutionstages();
  }

  private loadPokemon() {
    this.pgs.getAllPokemon().subscribe({
      next: (data) => {
        this.pokemonList$.next(data);  
        this.pokemonList = data;       
      },
      error: (err) => console.error('Error loading Pokémon:', err)
    });
  }

  private loadTypes() {
    this.typeserv.getAllTypes().subscribe({
      next: (data) => {
        this.types$.next(data);  
        this.types = data;       
      },
      error: (err) => console.error('Error loading Pokémon:', err)
    });
  }

  private loadMoves() {
    this.moveserv.getAllMoves().subscribe({
      next: (data) => {
        this.moves$.next(data);  
        this.moves = data;       
      },
      error: (err) => console.error('Error loading Pokémon:', err)
    });
  }

  private loadRegions() {
    this.regserv.getAllRegions().subscribe({
      next: (data) => {
        this.regions$.next(data);  
        this.regions = data;       
      },
       error: (err) => console.error('Error loading regions', err)
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

  private loadEvolutionstages(){
    this.ess.getAllEvolutionStages().subscribe({
      next: (data) => {
        this.evolutionStages$.next(data);  
        this.evolutionStages = data;       
      },
      error: (err) => console.error('Error loading Evo stages:', err)
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
  private convertToUpdateDto(pokemon: any): UpdatePokemon {
    return {
      pokemonName: formData.pokemonName,
      types: formData.types.map((id: number) => this.types.find(t => t.pokeTypeID === id)!),
      moves: formData.moves.map((id: number) => this.moves.find(m => m.moveID === id)!),
      regions: formData.regions.map((id: number) => this.regions.find(r => r.regionID === id)!),
      evolutionGroup: formData.evolutionGroup,
      trainer: formData.trainer,
      pokemonPicture: formData.pokemonPicture
    };
  }

  private initializeNewPokemon(): Pokemon {
    return {
      pokemonID: 0,
      pokemonName: '',
      pokemonPictureID: null,
      pokemonTrainerID: null,
      evolutionGroupID:  null,
      pokemonPicture:   null,
      trainer: null,
      types: [],
      moves: [],
      regions: [],
      evolutionGroup: null,
      evolutionStages: [{ groupID: 0, stageOrder: 1, pokemonID: 0 }]
    };
  }

  async deletePokemon(pokemonId: number) {
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
    const operation = this.isNewPokemon 
      ? this.pgs.createPokemon(this.selectedPokemon!)
      : this.pgs.updatePokemon(this.selectedPokemon!.pokemonID, this.convertToUpdateDto(this.selectedPokemon!));
  
    operation.subscribe({
      next: () => {
        this.loadPokemon();
        this.closeDrawer();
      },
      error: (err) => console.error('Error saving Pokémon:', err)
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

  validateMoveSelection(e: any) {
    const selectedMoves = e.value;
    return selectedMoves && selectedMoves.length >= 1 && selectedMoves.length <= 4;
  }

  validateTypeSelection(e: any) {
    const selectedTypes = e.value;
    return selectedTypes && selectedTypes.length >= 1 && selectedTypes.length <= 2;
  }
}
