import { Component, OnInit } from '@angular/core';
import { EvolutionStage } from '../models/evolution-stage.model';
import { EvolutionStageService } from '../services/evolution-stage.service';

@Component({
  selector: 'app-evolutions-link',
  templateUrl: './evolutions-link.component.html',
  styleUrl: './evolutions-link.component.scss'
})
export class EvolutionsLinkComponent implements OnInit {
  evolutions: EvolutionStage[] = [];

  constructor(private ess: EvolutionStageService) { }

  ngOnInit(): void {
    this.loadEvolutionStages();
  }

  loadEvolutionStages() {
    this.ess.getAllEvolutionStages().subscribe({
      next: (evolutions) => {
        this.evolutions = evolutions;
      },
      error: (err) => {
        console.error('Error loading evolution stages:', err);
      }
    });
  }
}