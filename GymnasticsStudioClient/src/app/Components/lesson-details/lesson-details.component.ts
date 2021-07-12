import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Lesson } from 'src/app/classes/lesson';
import { LessonService } from 'src/app/Services/lesson.service';

@Component({
  selector: 'app-lesson-details',
  templateUrl: './lesson-details.component.html',
  styleUrls: ['./lesson-details.component.css']
})
export class LessonDetailsComponent implements OnInit {
 
   
    id;
    lesson:Lesson;
    CurrentLesson = new Lesson ();
    SignUpForm = this.formBuilder.group({
      Name: new FormControl(''),
      TeacherId: new FormControl(''),
      Day: new FormControl(''),
      StartHower: new FormControl(''),
      phoneNumber: new FormControl(''),
      FinishHower: new FormControl(''),
      MaxStudensNum: new FormControl(''),
      LessonKind: new FormControl(''),
     
      



    
     
    });
  
    constructor(private lessonService: LessonService, private formBuilder: FormBuilder, private route: ActivatedRoute, private router: Router) {
     
      this.id = this.route.snapshot.paramMap.get('Id');
       this.getLessonDetailsByLessonId()
    }
  
    async getLessonDetailsByLessonId()
    {
      if (this.id != null && this.id != "") {
  
        if (this.id == "0")
        { 
          this.lesson= new Lesson();
          this.id= await this.lessonService.AddLesson(this.lesson).toPromise();
        }
        this.lessonService.getLessonDetailsByLessonId(this.id)
        .subscribe((res: Lesson) => {
          console.log("res: " + res)
          debugger;
          this.CurrentLesson = res
          debugger;
          this.BuildLessonDetailsForm();
        }, (error) => console.error)
    }
  }
  
    ngOnInit(): void {
      this.SignUpForm.disable()
    }
  
  
    BuildLessonDetailsForm() {
      this.SignUpForm.patchValue({
        Name: this.CurrentLesson.Name,
        TeacherId: this.CurrentLesson.TeacherId,
        Day: this.CurrentLesson.Day,
        StartHower: this.CurrentLesson.StartHower,
        FinishHower: this.CurrentLesson.FinishHower,
        MaxStudensNum: this.CurrentLesson.MaxStudensNum,
        LessonKind: this.CurrentLesson.LessonKind,
       
  
      })
    }
    Change() {
      this.SignUpForm.enable();
    }
  
    
    OnSubmit() {
      debugger
      var lesson = new Lesson(this.SignUpForm.value);
      lesson.Id = this.id;
      this.lessonService.PostLesson(lesson).subscribe(res => console.log(res), err => console.log(err))
    }
  }
  
  