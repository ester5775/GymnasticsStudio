import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FilesService {
  private url = 'http://localhost:54092/api/Files/'; 
  constructor(private http:HttpClient) { }
  upload(files):Observable<any> {
      var headers = new HttpHeaders();
      headers.append('Content-Type', 'application/x-www-form-urlencoded');
      //headers.append('parameters',parameters)
      return this.http.post(this.url + '/UploadFile',files );
    }
}
