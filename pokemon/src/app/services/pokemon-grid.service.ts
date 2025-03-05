import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../env/environment';
import { Pokemon, PokemonFullDto } from '../models/pokemon.model';

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

  createPokemon(pokemon: PokemonFullDto): Observable<PokemonFullDto> {
    return this.http.post<PokemonFullDto>(`${this.apiUrl}`, pokemon);
  }
  
  updatePokemon(id: number, pokemon: PokemonFullDto): Observable<PokemonFullDto> {
    return this.http.put<PokemonFullDto>(`${this.apiUrl}/${id}`, pokemon);
  }

  deletePokemon(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}