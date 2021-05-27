import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LessonInDate } from 'src/app/classes/lesson-in-date';
import { StudentInLesson } from 'src/app/classes/student-in-lesson';
import { StudentInLessonService } from 'src/app/Services/student-in-lesson.service';

@Component({
  selector: 'app-student-attendance-scadul',
  templateUrl: './student-attendance-scadul.component.html',
  styleUrls: ['./student-attendance-scadul.component.css']
})
export class StudentAttendanceScadulComponent implements OnInit {
  Id;
  AbsencesList:LessonInDate[];
  constructor(private route: ActivatedRoute,private studentInLessonService:StudentInLessonService){
    this.Id=route.snapshot.paramMap.get('Id');}

  ngOnInit(): void {
    this.studentInLessonService.getAbsencesListByStudentId(this.Id)
    .subscribe(AbsencesList => {
      this.AbsencesList=AbsencesList;
    });
  }

}
