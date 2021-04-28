import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Subscription } from '../classes/subscription';
import { Teacher } from '../classes/teacher';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  constructor(private http: HttpClient) { }

  private studentUrl = 'http://localhost:54092/api/Teacher/';
  

  getTeacherNameList(TeacherIdList:number[]):Observable<string[]>
  {
     return this.http.post<string[]>(this.studentUrl+"GetTeacherNameList",TeacherIdList);
  }
}
