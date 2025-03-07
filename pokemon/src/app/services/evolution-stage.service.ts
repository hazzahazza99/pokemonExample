import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../env/environment';
import { EvolutionStage } from '../models/evolution-stage.model';

@Injectable({
  providedIn: 'root'
})
export class EvolutionStageService {
  private apiUrl = `${environment.apiUrl}/api/evolution`;

  constructor(private http: HttpClient) { }

  getAllEvolutionStages(): Observable<EvolutionStage[]> {
    return this.http.get<EvolutionStage[]>(this.apiUrl);
  }
}