import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../env/environment';
import { Region } from '../models/region.model';

@Injectable({
  providedIn: 'root'
})
export class RegionsService {
  private apiUrl = `${environment.apiUrl}/api/region`;

  constructor(private http: HttpClient) { }

  getAllRegions(): Observable<Region[]> {
    return this.http.get<Region[]>(this.apiUrl);
  }
  
}