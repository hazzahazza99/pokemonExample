import { Component, OnInit } from '@angular/core';
import { Region } from '../models/region.model';
import { RegionsService } from '../services/regions.service';

@Component({
  selector: 'app-regions-grid',
  templateUrl: './regions-grid.component.html',
  styleUrl: './regions-grid.component.scss'
})
export class RegionsGridComponent implements OnInit {
  regions: Region[] = [];

  constructor(private typeService: RegionsService) { }

  ngOnInit(): void {
    this.loadRegions();
  }

  loadRegions() {
    this.typeService.getAllRegions().subscribe({
      next: (regions) => {
        this.regions = regions;
      },
      error: (err) => {
        console.error('Error loading types:', err);
      }
    });
  }
}