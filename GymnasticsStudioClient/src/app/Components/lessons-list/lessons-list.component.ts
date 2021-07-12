import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Lesson } from 'src/app/classes/lesson';
import { LessonService } from 'src/app/Services/lesson.service';

@Component({
  selector: 'app-lessons-list',
  templateUrl: './lessons-list.component.html',
  styleUrls: ['./lessons-list.component.css']
})
export class LessonsListComponent implements OnInit {

  // Name:[''],
  // TeacherId:[''],    
  // Day:[''],
  // StartHower:[''],
  // FinishHower:[''],
  // MaxStudensNum:[''],
  // LessonKind:[''],

  displayedColumns: string[] = ['Name','TeacherId', 'Day','Hower'];  
  LessonList:Array<Lesson>;
  Lesson:Lesson;
  SearchForm:FormGroup;
  constructor(private route: ActivatedRoute,private router: Router, private LessonService:LessonService,private formBuilder: FormBuilder) {
   
   }

   ngOnInit(): void {
    
    this.GetLessonList();
   
    this.SearchForm = this.formBuilder.group({
      Name:[''],
      TeacherId:[''],    
      Day:[''],
      StartHower:[''],
      FinishHower:[''],
    
    });
    
  }

 

  GetLessonList()
  {
    
    this.LessonService.getLessonList()
      .subscribe(LessonList => {
        this.LessonList=LessonList;
      });
  }

 

  OpenLessonDetails(LessonId:number){
    
   // this.student=element;
    this.router.navigateByUrl("lesson/lessons-list/(lessonOptionsRouterOutlet:edit-lesson/"+LessonId+")");
  }


 
   
  AddLesson(){
    
    this.router.navigateByUrl("lesson/lessons-list/(lessonOptionsRouterOutlet:edit-lesson/0");
  }


  

}
  