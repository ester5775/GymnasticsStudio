import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Lesson } from '../classes/lesson';

@Injectable({
  providedIn: 'root'
})
export class LessonService {
  constructor( private http: HttpClient) { }

  private studentUrl = 'http://localhost:54092/api/Lesson/'; 

  getLessonsListByStudentId(Id:Number): Observable<Lesson[]> {
    return this.http.get<Lesson[]>(this.studentUrl+"GetLessonsListByStudentId/${Id}");
  }
}