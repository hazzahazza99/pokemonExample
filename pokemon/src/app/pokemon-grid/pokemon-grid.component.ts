import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Pokemon, UpdatePokemon } from '../models/pokemon.model';
import { PokemonGridService } from '../services/pokemon-grid.service';
import { confirm } from 'devextreme/ui/dialog';
import { DxDataGridTypes } from 'devextreme-angular/ui/data-grid';

interface PokemonGridColumn extends DxDataGridTypes.Column {
  dataField: string;
  caption: string;
  calculateCellValue?: (rowData: any) => string;
  cellTemplate?: string;
}

@Component({
  selector: 'app-pokemon-grid',
  templateUrl: './pokemon-grid.component.html',
  styleUrls: ['./pokemon-grid.component.scss']
})
export class PokemonGridComponent implements OnInit {
  isDrawerOpen = false;
  selectedPokemon: Pokemon | null = null;
  pokemonList$ = new BehaviorSubject<Pokemon[]>([]);
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
      calculateCellValue: (rowData: { types?: string[] }) =>
        (rowData.types || []).join(', ')
    },
    {
      dataField: 'moves',
      caption: 'Moves',
      calculateCellValue: (rowData: { moves?: string[] }) =>
        (rowData.moves || []).join(', ')
    },
    {
      dataField: 'regions',
      caption: 'Regions',
      calculateCellValue: (rowData: { regions?: string[] }) =>
        (rowData.regions || []).join(', ')
    },
    {
      dataField: 'evolutionGroup.evolutionStages',
      caption: 'Evolution Stages',
      calculateCellValue: (rowData: { evolutionGroup?: { evolutionStages?: any[] } }) => {
        if (!rowData.evolutionGroup?.evolutionStages) return 'N/A';
        return rowData.evolutionGroup.evolutionStages
          .map(stage => `${stage.stageOrder}: ${stage.pokemon.pokemonName}`)
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

  constructor(private pgs: PokemonGridService) {}

  ngOnInit(): void {
    this.loadPokemon();
  }

  private loadPokemon() {
    this.pgs.getAllPokemon().subscribe({
      next: (data) => {
        this.pokemonList$.next(data);
      },
      error: (err) => console.error('Error loading Pokémon:', err)
    });
  }

  openDrawer(pokemon?: Pokemon) {
    this.isNewPokemon = !pokemon;
    this.selectedPokemon = pokemon ? { ...pokemon } : this.initializeNewPokemon();
    this.isDrawerOpen = true;
  }

  private initializeNewPokemon(): Pokemon {
    return {
      pokemonID: 0,
      pokemonName: '',
      types: [],
      moves: [],
      regions: [],
      pokemonPicture: { 
        pictureID: 0, 
        picturePath: 'assets/default-pokemon.png' 
      },
      evolutionGroup: undefined,
      trainer: undefined
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

  saveChanges() {
    if (!this.validateForm()) return;
  
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
  
  private convertToUpdateDto(pokemon: Pokemon): UpdatePokemon {
    return {
      pokemonName: pokemon.pokemonName,
      types: pokemon.types,
      moves: pokemon.moves,
      regions: pokemon.regions,
      evolutionGroup: pokemon.evolutionGroup || null,
      trainer: pokemon.trainer || null,
      pokemonPicture: pokemon.pokemonPicture
    };
  }

  private validateForm(): boolean {
    if (!this.selectedPokemon?.pokemonName?.trim()) {
      alert('Pokémon name is required');
      return false;
    }
    return true;
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
}