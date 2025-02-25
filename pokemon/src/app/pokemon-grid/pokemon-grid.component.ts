import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Pokemon } from '../models/pokemon.model';
import { PokemonGridService } from '../services/pokemon-grid.service';
import { DxDrawerTypes } from 'devextreme-angular/ui/drawer';

@Component({
  selector: 'app-pokemon-grid',
  templateUrl: './pokemon-grid.component.html',
  styleUrl: './pokemon-grid.component.scss'
})
export class PokemonGridComponent implements OnInit {
  isDrawerOpen = false;
  selectedPokemon: Pokemon | null = null;
  pokemonList$ = new BehaviorSubject<Pokemon[]>([]);
  

  columns = [
    { dataField: 'pokemonName', caption: 'Pokemon Name' },
    { 
      dataField: 'trainer.trainerName', 
      caption: 'Trainer Name',
      calculateCellValue: (rowData: { trainer?: { trainerName?: string } }) => 
        rowData.trainer?.trainerName || 'N/A'
    },
    {
      dataField: 'pokemonRegions',
      caption: 'Regions',
      calculateCellValue: (rowData: { pokemonRegions?: any[] }) =>
        (rowData.pokemonRegions || []).map(region => region.regionName).join(', ')
    },
    {
      dataField: 'movesets',
      caption: 'Moveset',
      calculateCellValue: (rowData: { movesets?: any[] }) =>
        (rowData.movesets || []).map(move => move.moveName).join(', ')
    },
    { 
      dataField: 'evolutionGroup.evolutionGroupName', 
      caption: 'Evolution Group',
      calculateCellValue: (rowData: { evolutionGroup?: { evolutionGroupName?: string } }) => 
        rowData.evolutionGroup?.evolutionGroupName || 'N/A'
    },
    {
      dataField: 'pictureURL',
      caption: 'Pokemon Image',
      cellTemplate: (container: { appendChild: (arg0: HTMLImageElement) => void; }, options: { value: string; }) => {
        const imgElement = document.createElement('img');
        imgElement.src = options.value;
        imgElement.width = 50;
        imgElement.height = 50;
        container.appendChild(imgElement);
      }
    }
  ];

  constructor(private pgs: PokemonGridService) {}

  ngOnInit(): void {
    this.pgs.getAllPokemon().subscribe(
      (data: Pokemon[]) => {
        console.log('Fetched Pokémon:', data);
        this.pokemonList$.next(data);
      },
      error => console.error('Error fetching Pokémon:', error)
    );
  }

  openDrawer(event: any) {
    this.selectedPokemon = { ...event.data };
    this.isDrawerOpen = true;
  }

  saveChanges() {
    console.log('Saving changes...', this.selectedPokemon);
    this.isDrawerOpen = false;
  }

  handleDrawerClose(event: any) {
    if (event.name === 'opened' && !event.value) {
      this.isDrawerOpen = false;
    }
  }
}