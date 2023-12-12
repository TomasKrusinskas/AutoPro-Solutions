import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TechnicianService {
  constructor(private _http: HttpClient) {}

  addTechnician(data: any): Observable<any> {
    return this._http.post('http://localhost:3000/technicians', data);
  }

  updateTechnician(id: number, data: any): Observable<any> {
    return this._http.put(`http://localhost:3000/technicians/${id}`, data);
  }

  getTechnician(): Observable<any> {
    return this._http.get('http://localhost:3000/technicians');
  }

  deleteTechnician(id: number): Observable<any> {
    return this._http.delete(`http://localhost:3000/technicians/${id}`);
  }
}
