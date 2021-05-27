import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-students-files',
  templateUrl: './students-files.component.html',
  styleUrls: ['./students-files.component.css']
})
export class StudentsFilesComponent implements OnInit {

  Id;
  srcResult;
  pdfSource="C:\Users\User\Desktop\Ester Levcovich\GymnasticsStudio\GymnasticsStudioClient\src\app\Fiels\מסכים לתכנות 28.2.21.pdf"
  constructor(private route: ActivatedRoute) { 
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
  
}
