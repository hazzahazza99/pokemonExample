import { Injectable } from '@angular/core';
import { environment } from '../env/environment';
import { HttpClient } from '@angular/common/http';
import { Trainer } from '../models/trainer.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TrainerGridService {
 private apiUrl = `${environment.apiUrl}/api/trainer`;

  constructor(private http: HttpClient) { }

  getAllTrainers(): Observable<Trainer[]> {
    return this.http.get<Trainer[]>(this.apiUrl);
  }

  getTrainersById(id: number): Observable<Trainer> {
    return this.http.get<Trainer>(`${this.apiUrl}/${id}`);
  }

  updateTrainer(trainer: Trainer): Observable<Trainer> {
    return this.http.put<Trainer>(
      `${this.apiUrl}/${trainer.trainerID}`,
      trainer                                
    );
  }

  createTrainers(trainer: Trainer): Observable<Trainer> {
    return this.http.post<Trainer>(this.apiUrl, trainer);
  }

  deleteTrainers(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}