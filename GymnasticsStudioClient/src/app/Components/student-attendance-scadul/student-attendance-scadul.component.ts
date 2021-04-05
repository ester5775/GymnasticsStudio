import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-student-attendance-scadul',
  templateUrl: './student-attendance-scadul.component.html',
  styleUrls: ['./student-attendance-scadul.component.css']
})
export class StudentAttendanceScadulComponent implements OnInit {
  Id;
  constructor(private route: ActivatedRoute){
    this.Id=route.snapshot.paramMap.get('Id');}

  ngOnInit(): void {
  }

}
