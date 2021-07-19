import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UploadsFileDTO } from '../classes/UploadsFile';

@Injectable({
  providedIn: 'root'
})
export class FileServiceService {

  private url = 'http://localhost:54092/api/File/'; 
  constructor(private http:HttpClient) { }
  upload(files):Observable<any> {
      var headers = new HttpHeaders(); 
      headers.append('Content-Type', 'application/x-www-form-urlencoded');
      //headers.append('parameters',parameters)
      return this.http.post(this.url + 'UploadFile',files );
    }
    GetFilesPerStudent(id:number):Observable<UploadsFileDTO[]>{
      return this.http.get<UploadsFileDTO[]>(this.url + 'GetFilesPerStudent?Id='+id );
    }
}


