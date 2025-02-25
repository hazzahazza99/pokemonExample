import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../env/environment';
import { Pokemon, UpdatePokemon } from '../models/pokemon.model';

@Injectable({
  providedIn: 'root'
})
export class PokemonGridService {

  private apiUrl = `${environment.apiUrl}/api/pokemon`;

  constructor(private http: HttpClient) {}

  getAllPokemon(): Observable<Pokemon[]> {
    return this.http.get<Pokemon[]>(`${this.apiUrl}/pokemon`);
  }

  updatePokemon(id: number, updatedData: UpdatePokemon): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/pokemon/${id}`, updatedData);
  }

  deletePokemon(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/pokemon/${id}`);
  }
}
