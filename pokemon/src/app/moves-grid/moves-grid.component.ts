import { Component, OnInit, ViewChild } from '@angular/core';
import { DxFormComponent } from 'devextreme-angular';
import { Move } from '../models/move.model';
import { PokemonMoveService } from '../services/moves-grid.service';
import { PokemonTypeService } from '../services/types-list.service';
import { PokemonType } from '../models/pokemon-type.model';

@Component({
  selector: 'app-moves-grid',
  templateUrl: './moves-grid.component.html',
  styleUrl: './moves-grid.component.scss'
})
export class MovesGridComponent implements OnInit {
  @ViewChild(DxFormComponent) form!: DxFormComponent;
  moves: Move[] = [];
  type: PokemonType[] = [];
  moveFormData: Partial<Move> = {};
  addButtonOptions: any;

  constructor(private moveService: PokemonMoveService, private typeService: PokemonTypeService) {
    this.addButtonOptions = {
      text: 'Add Move',
      type: 'success',
      useSubmitBehavior: true,
      onClick: () => this.addMove()
    };
  }

  ngOnInit(): void {
    this.loadMoves();
    this.loadTypes();
  }

  loadMoves(): void {
    this.moveService.getAllMoves().subscribe({
      next: (moves) => this.moves = moves,
      error: (err) => console.error('Error loading moves:', err)
    });
  }

  loadTypes() {
    this.typeService.getAllTypes().subscribe({
      next: (types) => this.type = types,
      error: (err) => console.error('Error loading moves:', err)
    });
  }

  addMove(): void {
    const result = this.form.instance.validate();
    if (!result.isValid) {
      return;
    }

    this.moveService.createMove(this.moveFormData as Move).subscribe({
      next: () => {
        this.loadMoves();
      },
      error: (err) => console.error('Error creating move:', err)
    });
  }
}
