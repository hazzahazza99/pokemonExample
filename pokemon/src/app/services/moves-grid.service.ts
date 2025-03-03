import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../env/environment';
import { Move } from '../models/move.model';

@Injectable({
  providedIn: 'root'
})
export class PokemonMoveService {
  private apiUrl = `${environment.apiUrl}/api/move`;

  constructor(private http: HttpClient) { }

  getAllMoves(): Observable<Move[]> {
    return this.http.get<Move[]>(this.apiUrl);
  }

  createMove(move: Move): Observable<Move> {
      return this.http.post<Move>(this.apiUrl, move);
    }
}