import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Screening } from '../models/screening.model';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ScreeningService {

  constructor(private http: HttpClient) { }
  baseUrl: string = environment.baseUrl;

  getAllScreening(): Observable<Screening[]>{
    return this.http.get<Screening[]>(this.baseUrl + '/api/Screening')
  }

  addScreening(addScreeningRequest: Screening): Observable<Screening> {
    
    return this.http.post<Screening>(this.baseUrl + '/api/Screening', addScreeningRequest);

  }

  getScreening(id: string): Observable<Screening> {
    
    return this.http.get<Screening>(this.baseUrl + '/api/Screening/' + id);

  }

  updateScreening(id: string, editScreeningRequest: Screening): Observable<Screening> {
    
    return this.http.put<Screening>(this.baseUrl + '/api/Screening/' + id, editScreeningRequest);

  }
  
  deleteScreening(id: string): Observable<Screening> {
    
    return this.http.delete<Screening>(this.baseUrl + '/api/Screening/' + id);

  }
}
