import { Component, OnInit } from '@angular/core';
import { PokemonTypeService } from '../services/types-list.service';
import { PokemonType } from '../models/pokemon-type.model';

@Component({
  selector: 'app-types-list',
  templateUrl: './types-list.component.html',
  styleUrls: ['./types-list.component.scss']
})
export class TypesListComponent implements OnInit {
  types: PokemonType[] = [];

  constructor(private typeService: PokemonTypeService) { }

  ngOnInit(): void {
    this.loadTypes();
  }

  loadTypes() {
    this.typeService.getAllTypes().subscribe({
      next: (types) => {
        this.types = types;
      },
      error: (err) => {
        console.error('Error loading types:', err);
      }
    });
  }
}
