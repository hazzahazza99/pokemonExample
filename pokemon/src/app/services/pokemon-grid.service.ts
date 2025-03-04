import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../env/environment';
import { Pokemon, UpdatePokemon } from '../models/pokemon.model';

@Injectable({
  providedIn: 'root'
})
export class PokemonGridService {
  private apiUrl = `${environment.apiUrl}/api/pokemonfull`;

  constructor(private http: HttpClient) { }

  getAllPokemon(): Observable<Pokemon[]> {
    return this.http.get<Pokemon[]>(this.apiUrl);
  }

  getPokemonById(id: number): Observable<Pokemon> {
    return this.http.get<Pokemon>(`${this.apiUrl}/${id}`);
  }

  createPokemon(pokemon: Pokemon): Observable<Pokemon> {
    const payload = { pokemonDto: pokemon };
    return this.http.post<Pokemon>(`${this.apiUrl}`, payload);
  }

  updatePokemon(id: number, pokemon: UpdatePokemon): Observable<Pokemon> {
    const payload = { pokemonDto: pokemon };
    return this.http.put<Pokemon>(`${this.apiUrl}/${id}`, payload);
  }

  deletePokemon(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}