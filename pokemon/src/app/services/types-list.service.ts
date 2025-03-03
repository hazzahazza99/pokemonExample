import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../env/environment';
import { PokemonType } from '../models/pokemon-type.model';

@Injectable({
  providedIn: 'root'
})
export class PokemonTypeService {
  private apiUrl = `${environment.apiUrl}/api/type`;

  constructor(private http: HttpClient) { }

  getAllTypes(): Observable<PokemonType[]> {
    return this.http.get<PokemonType[]>(this.apiUrl);
  }
  
}