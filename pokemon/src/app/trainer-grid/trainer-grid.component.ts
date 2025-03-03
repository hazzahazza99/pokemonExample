// trainer-grid.component.ts
import { Component, OnInit } from '@angular/core';
import { Trainer } from '../models/trainer.model';
import { TrainerGridService } from '../services/trainer-grid.service';

@Component({
  selector: 'app-trainer-grid',
  templateUrl: './trainer-grid.component.html',
  styleUrls: ['./trainer-grid.component.scss']
})
export class TrainerGridComponent implements OnInit {
  isDrawerOpen = false;
  selectedTrainer: Trainer | null = null;
  isNewTrainer = false;
  trainers: Trainer[] = [];

  columns = [
    { dataField: 'trainerID', caption: 'ID', width: 80 },
    { dataField: 'trainerName', caption: 'Name' },
    { dataField: 'trainerAge', caption: 'Age', width: 100 },
    { dataField: 'trainerBadge', caption: 'Badges', width: 100 },
    { 
      dataField: 'trainerPhotoID', 
      caption: 'Photo',
      cellTemplate: 'photoTemplate'
    },
    { 
      dataField: 'trainerIsGymLeader', 
      caption: 'Gym Leader',
      dataType: 'boolean'
    }
  ];

  constructor(private trainerService: TrainerGridService) {}

  ngOnInit() {
    this.loadTrainers();
  }

  private loadTrainers() {
    this.trainerService.getAllTrainers().subscribe({
      next: (data) => this.trainers = data,
      error: (err) => console.error('Error loading trainers:', err)
    });
  }

  getPhotoUrl(photoId: number): string {
    return `https://your-api-endpoint/photos/${photoId}`;
  }

  openDrawer(trainer?: Trainer) {
    this.isNewTrainer = !trainer;
    this.selectedTrainer = trainer ? { ...trainer } : this.newTrainer();
    this.isDrawerOpen = true;
  }

  closeDrawer() {
    this.isDrawerOpen = false;
    this.selectedTrainer = null;
  }

  handleDrawerState(e: any) {
    if (e.name === 'opened') {
      this.isDrawerOpen = e.value;
      if (!e.value) this.closeDrawer();
    }
  }

  saveTrainer() {
    if (!this.validateTrainer()) return;
  
    const operation = this.isNewTrainer
      ? this.trainerService.createTrainers(this.selectedTrainer!)
      : this.trainerService.updateTrainer(this.selectedTrainer!);
  
    operation.subscribe({
      next: (updatedTrainer) => {
        if (this.isNewTrainer) {
          this.trainers = [...this.trainers, updatedTrainer];
        } else {
          this.trainers = this.trainers.map(t => 
            t.trainerID === updatedTrainer.trainerID ? updatedTrainer : t
          );
        }
        this.closeDrawer();
      },
      error: (err) => console.error('Error saving trainer:', err)
    });
  }

  private newTrainer(): Trainer {
    return {
      trainerID: 0,
      trainerName: '',
      trainerAge: 18,
      trainerBadge: 0,
      trainerIsGymLeader: false,
      trainerPhotoID: 0
    };
  }

  private validateTrainer(): boolean {
    return !!this.selectedTrainer?.trainerName?.trim();
  }
}