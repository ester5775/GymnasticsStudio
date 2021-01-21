import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-pay-details',
  templateUrl: './student-pay-details.component.html',
  styleUrls: ['./student-pay-details.component.css']
})
export class StudentPayDetailsComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

}
