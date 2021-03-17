import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Lesson } from 'src/app/classes/lesson';

@Component({
  selector: 'app-student-scadul',
  templateUrl: './student-scadul.component.html',
  styleUrls: ['./student-scadul.component.css']
})
export class StudentScadulComponent implements OnInit {

  Id;
  LessonsList:Array<Lesson>
  constructor(private route: ActivatedRoute){
    this.Id=route.snapshot.paramMap.get('Id');}


  ngOnInit(): void {
  }

}
