import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Week } from '../classes/week';

@Injectable({
  providedIn: 'root'
})
export class WeekService {

  constructor(private http: HttpClient) { }

  private studentUrl = 'http://localhost:54092/api/Week/';
  
  getWeekDetailsByWeekId(id:number): Observable<Week> {
    return this.http.get<Week>(this.studentUrl+"GetWeekDetailsByWeekId/"+id);
  }

 
  PostWeek(Week:Week):Observable<boolean> {
    return this.http.post<boolean>(this.studentUrl+"EditWeek",Week);
  }

  AddWeek(Week:Week):Observable<number> {
    return this.http.put<number>(this.studentUrl+"AddWeek",Week);
  }

  
  
}