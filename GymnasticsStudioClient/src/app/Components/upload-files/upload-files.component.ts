import { Component, OnInit } from '@angular/core';
import { FilesService } from 'src/app/Services/files.service';

@Component({
  selector: 'app-up-load-files',
  templateUrl: './up-load-files.component.html',
  styleUrls: ['./up-load-files.component.css']
})
export class UpLoadFilesComponent implements OnInit {

  constructor(private FileService: FilesService) { }

  ngOnInit(): void {
  }
  onFileChange(event) {
    let files = event.target.files;
    if (files.length > 0) {
      this.saveFiles(files)
    }

  }
  saveFiles(files) {
    let formData: FormData = new FormData();
    debugger
    formData.append(files[0].name, files[0]);
    //formData.append("storeId",this.authservice.getUserId().toString())
    //let date=files[0].lastModifiedDate;
    //formData.append("date",date.toTimeString())
    //var parameters = {
    //storeId: this.authservice.getUserId(),
    //date:files[0].lastModifiedDate
    //}
    // this.fileservice.upload(formData,parameters).subscribe(
    this.FileService.upload(formData).subscribe(
      (res) => {
        if (res) {
          alert("הקובץ הועלה בהצלחה")
          console.log("Upload success")
        }
      },
      error => {
        debugger
        console.log(error)
      })

  }
}
