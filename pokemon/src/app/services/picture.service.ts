import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../env/environment';
import { Picture } from '../models/picture.model';

@Injectable({
  providedIn: 'root'
})
export class PictureService {
  private apiUrl = `${environment.apiUrl}/api/picture`;

  constructor(private http: HttpClient) { }

  getAllPictures(): Observable<Picture[]> {
    return this.http.get<Picture[]>(this.apiUrl);
  }
  
}