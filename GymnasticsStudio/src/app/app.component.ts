import { Component } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'GymnasticsStudio';
  constructor(private route: ActivatedRoute,private router: Router,public sanitizer: DomSanitizer) { }

ShowStudentsList()
  {
    this.router.navigate(['students-list']);
  }
}