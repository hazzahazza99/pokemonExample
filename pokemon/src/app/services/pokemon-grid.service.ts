import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../env/environment';
import { Pokemon } from '../models/pokemon.model';

@Injectable({
  providedIn: 'root'
})
export class PokemonGridService {
  private apiUrl = `${environment.apiUrl}/api/pokemonfull`;

  constructor(private http: HttpClient) { }

  getAllPokemon(): Observable<Pokemon[]> {
    return this.http.get<Pokemon[]>(this.apiUrl);
  }

  createPokemon(pokemon: Pokemon): Observable<Pokemon> {
    return this.http.post<Pokemon>(this.apiUrl, pokemon);
  }
  
  updatePokemon(id: number, dto: Pokemon): Observable<Pokemon> {
    return this.http.put<Pokemon>(`${this.apiUrl}/${id}`, dto);
  }

  deletePokemon(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}