import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { Lesson } from 'src/app/classes/lesson';
import { StudentInSubscription } from 'src/app/classes/student-in-subscription';
import { Subscription } from 'src/app/classes/subscription';
import { Teacher } from 'src/app/classes/teacher';
import { LessonService } from 'src/app/Services/lesson.service';
import { StudentInSubscriptionService } from 'src/app/Services/student-in-subscription.service';
import { StudentService } from 'src/app/Services/student.service';
import { SubscriptionService } from 'src/app/Services/subscription.service';
import { TeacherService } from 'src/app/Services/teacher.service';
import { DateDialogBoxComponent } from '../date-dialog-box/date-dialog-box.component';

@Component({
  selector: 'app-student-scadul',
  templateUrl: './student-scadul.component.html',
  styleUrls: ['./student-scadul.component.css']
})
export class StudentScadulComponent implements OnInit {

  Id;
  studentsKind;
  LessonsList:Array<Lesson>
  SubscriptionList:Array<Subscription>;
  CurrentSubscription:Subscription;
  CurrentStudentInSubscription:StudentInSubscription;
  NewStudentInSubscription:StudentInSubscription;
  SubsctiptionId:number;
  WeekNum:number;
  Balance:number;
  status:string="זכות";
  TeacherIdList:number[];
  TeacherNameList:string[];
  Date:string;
  constructor(private route: ActivatedRoute,private studentInSubscriptionService:StudentInSubscriptionService,
    private studentService:StudentService,private subscriptionService:SubscriptionService,private lessonService:LessonService,
    private teacherService:TeacherService,public dialog: MatDialog) {
    
    this.Id=route.snapshot.paramMap.get('Id');}
    


  async ngOnInit(): Promise<void> {

    this.CurrentSubscription= await this.studentInSubscriptionService.getCurrentSubscription(this.Id).toPromise();
    this.CurrentStudentInSubscription=await this.studentInSubscriptionService.getCurrentStudentInSubscription(this.Id).toPromise();
    this.WeekNum = await this.studentInSubscriptionService.getCurrentWeekNum(this.Id).toPromise();
    this.Balance= await this.studentService.getBalance(this.Id).toPromise();
    if(this.Balance<0)
    {
    status="חוב";
    }
  }

  async FullSubscriptionMenue()
  {
    
    this.SubscriptionList = await this.subscriptionService.getSubscriptionList(this.Id).toPromise();
  }

  EditSubscription(subscription:Subscription)
  {
    this.NewStudentInSubscription=new StudentInSubscription();
    this.NewStudentInSubscription.StartDate=this.CurrentStudentInSubscription.FinishDate;
    this.NewStudentInSubscription.StudentId=this.CurrentStudentInSubscription.StudentId;
    this.NewStudentInSubscription.SubscribtionId=subscription.Id;
    this.studentInSubscriptionService.AddStudentInSubscription(this.NewStudentInSubscription).subscribe(res=>console.log(res),err=>console.log(err))
   
  }
 
  openDialog(): void {
    const dialogRef = this.dialog.open(DateDialogBoxComponent, {
      width: '250px',
      data: {Date:this.Date},
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.Date = result;
      this.FullLessonMenue();
    });
  }

  async FullLessonMenue()
  {
    
    this.LessonsList = await this.lessonService.getLessonsListBySubscriptionByStudentIdEndDate(parseInt(this.Id),this.Date).toPromise();
    this.TeacherIdList=new Array<number>();
    this.LessonsList.forEach(lesson=>this.TeacherIdList.push(lesson.TeacherId));

    this.TeacherNameList = await this.teacherService.getTeacherNameList(this.TeacherIdList).toPromise();

  }


  EditLesson(lesson)
  {
    console.log("res")
  }
}




