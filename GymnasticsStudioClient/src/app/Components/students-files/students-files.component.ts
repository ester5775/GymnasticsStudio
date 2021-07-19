import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UploadsFileDTO } from 'src/app/classes/UploadsFile';
import { FileServiceService } from 'src/app/Services/file-service.service';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-students-files',
  templateUrl: './students-files.component.html',
  styleUrls: ['./students-files.component.css']
})
export class StudentsFilesComponent implements OnInit {

  Id;
  srcResult;
  StudentDocs: UploadsFileDTO[] = [];
  pdfSource = "C:\Users\User\Desktop\Ester Levcovich\GymnasticsStudio\GymnasticsStudioClient\src\app\Fiels\מסכים לתכנות 28.2.21.pdf"
  constructor(private route: ActivatedRoute, private fileService: FileServiceService, private sanitizer: DomSanitizer) {
    this.Id = route.snapshot.paramMap.get('Id');
  }

  ngOnInit(): void {
    this.InitFiles();
  }
  InitFiles() {
    this.fileService.GetFilesPerStudent(this.Id).subscribe(
      (res: UploadsFileDTO[]) => { this.StudentDocs = res; },
      err => { console.log("שגיאה בקבלת הקבצים" + err) })
  }

  sanitizeImageUrl(imageUrl: string): SafeUrl {
     return this.sanitizer.bypassSecurityTrustResourceUrl(imageUrl); 
  }

  // onFileSelected() {
  //   const inputNode: any = document.querySelector('#file');

  //   if (typeof (FileReader) !== 'undefined') {
  //     const reader = new FileReader();

  //     reader.onload = (e: any) => {
  //       this.srcResult = e.target.result;
  //     };

  //     reader.readAsArrayBuffer(inputNode.files[0]);
  //   }
  // }



  onFileChange(event) {
    debugger
    let files = event.target.files;
    if (files.length > 0) {
      this.saveFiles(files)
      this.InitFiles();
    }

  }
  saveFiles(files) {
    let formData: FormData = new FormData();
    formData.append(files[0].name, files[0]);
    formData.append("StudentId", this.Id);
    this.fileService.upload(formData).subscribe(
      (res) => {
        if (res) {
          alert("עלה בהצלחה" + " מספר מזהה: " + res)
          console.log("Upload success")
        }
      },
      error => {
        debugger
        console.log(error)
      })

  }
}
