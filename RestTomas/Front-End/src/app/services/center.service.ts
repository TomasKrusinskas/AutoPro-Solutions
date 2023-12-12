import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CenterService {
  constructor(private _http: HttpClient) {}

  addCenter(data: any): Observable<any> {
    return this._http.post('http://localhost:3000/centers', data);
  }

  updateCenter(id: number, data: any): Observable<any> {
    return this._http.put(`http://localhost:3000/centers/${id}`, data);
  }

  getCenters(): Observable<any> {
    return this._http.get('http://localhost:3000/centers');
  }

  deleteCenter(id: number): Observable<any> {
    return this._http.delete(`http://localhost:3000/centers/${id}`);
  }
}
