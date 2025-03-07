import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../env/environment';
import { PokemonType } from '../models/pokemon-type.model';
import { Move } from '../models/move.model';
import { Region } from '../models/region.model';
import { Trainer } from '../models/trainer.model';

@Injectable({ providedIn: 'root' })
export class CommonService {
  private apiPath = `${environment.apiUrl}/api/gridcommon`;
  constructor(private http: HttpClient) {}

  getAllCommonData(): Observable<{
    types: PokemonType[];
    moves: Move[];
    regions: Region[];
    trainers: Trainer[];
  }> {
    return this.http.get<{
      types: PokemonType[];
      moves: Move[];
      regions: Region[];
      trainers: Trainer[];
    }>(this.apiPath);
  }
}