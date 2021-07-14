import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FileServiceService } from 'src/app/Services/file-service.service';

@Component({
  selector: 'app-students-files',
  templateUrl: './students-files.component.html',
  styleUrls: ['./students-files.component.css']
})
export class StudentsFilesComponent implements OnInit {

  Id;
  srcResult;
  pdfSource="C:\Users\User\Desktop\Ester Levcovich\GymnasticsStudio\GymnasticsStudioClient\src\app\Fiels\מסכים לתכנות 28.2.21.pdf"
  constructor(private route: ActivatedRoute,private fileService:FileServiceService) { 
    this.Id=route.snapshot.paramMap.get('Id');
  }

  ngOnInit(): void {
  }

  onFileSelected() {
    const inputNode: any = document.querySelector('#file');
  
    if (typeof (FileReader) !== 'undefined') {
      const reader = new FileReader();
  
      reader.onload = (e: any) => {
        this.srcResult = e.target.result;
      };
  
      reader.readAsArrayBuffer(inputNode.files[0]);
    }
  }
  


  onFileChange(event) {
    let files = event.target.files;
    if (files.length > 0) {
      this.saveFiles(files)
    }

  }
  saveFiles(files) {
    let formData: FormData = new FormData();
    formData.append(files[0].name, files[0]);
    this.fileService.upload(formData).subscribe(
      (res) => {
        if (res) {
          alert("עלה בהצלחה"+" מספר מזהה: "+res)
          console.log("Upload success")
        }
      },
      error => {
        debugger
        console.log(error)
      })

  }
}
