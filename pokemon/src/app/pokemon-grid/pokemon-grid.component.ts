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
  pokemonList: Pokemon[] = [];  
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

  constructor(private pgs: PokemonGridService) {}

  ngOnInit(): void {
    this.loadPokemon();
  }

  private loadPokemon() {
    this.pgs.getAllPokemon().subscribe({
      next: (data) => {
        this.pokemonList$.next(data);  // Update the observable list
        this.pokemonList = data;       // Store the full list for lookup
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
      pokemonPictureID: null,
      pokemonTrainerID: null,
      evolutionGroupID:  null,
      pokemonPicture:   null,
      trainer: null,
      types: [],
      moves: [],
      regions: [],
      evolutionGroup: null,
      evolutionStages: []
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
