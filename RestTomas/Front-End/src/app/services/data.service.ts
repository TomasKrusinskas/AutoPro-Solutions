import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private apiUrl = 'http://localhost:5000';

  constructor(private http: HttpClient) { }
  getCenters(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/centers`);
  }
  getTechnicians(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/technicians`);
  }

  // Add other CRUD methods as needed
}
