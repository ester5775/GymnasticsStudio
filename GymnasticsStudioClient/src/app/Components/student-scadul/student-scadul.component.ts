import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { Lesson } from 'src/app/classes/lesson';
import { ParticularSubscription } from 'src/app/classes/particular-subscription';
import { StudentInSubscription } from 'src/app/classes/student-in-subscription';
import { Subscription } from 'src/app/classes/subscription';
import { Teacher } from 'src/app/classes/teacher';
import { LessonService } from 'src/app/Services/lesson.service';
import { ParticularSubscriptionService } from 'src/app/Services/particular-subscription.service';
import { StudentInLessonService } from 'src/app/Services/student-in-lesson.service';
import { StudentInSubscriptionService } from 'src/app/Services/student-in-subscription.service';
import { StudentService } from 'src/app/Services/student.service';
import { SubscriptionService } from 'src/app/Services/subscription.service';
import { TeacherService } from 'src/app/Services/teacher.service';
import { DateDialogBoxComponent } from '../date-dialog-box/date-dialog-box.component';
import { ParticularSubscriptionDialgBoxComponent } from '../particular-subscription-dialg-box/particular-subscription-dialg-box.component';
import { MatSnackBar,MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition,} from '@angular/material/snack-bar';
import { ExceptionsEnum } from 'src/app/Enums/exceptions-enum.enum';

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
  ParticularSubscription:ParticularSubscription;
  FullLesson:boolean=false;
  LessonOfSubscriptionList:Array<Lesson>;
  StudentInSubscreption:StudentInSubscription;
  horizontalPosition: MatSnackBarHorizontalPosition = 'center';
  verticalPosition: MatSnackBarVerticalPosition = 'top';


  constructor(private route: ActivatedRoute,private studentInSubscriptionService:StudentInSubscriptionService,
    private studentService:StudentService,private subscriptionService:SubscriptionService,
    private lessonService:LessonService,private teacherService:TeacherService,
    private studentInLessonService:StudentInLessonService,public dialog: MatDialog,
    private particularSubscriptionService:ParticularSubscriptionService,
    private LessonService:LessonService,
    private _snackBar: MatSnackBar) {
    
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
    
    this.SubscriptionList = await this.subscriptionService.getSubscriptionListByStudent(this.Id).toPromise();
  }

  EditSubscription(SubsctiptionId:number)
  {  
    this.studentInSubscriptionService.EditSubscription(this.CurrentStudentInSubscription.Id,SubsctiptionId)
    .subscribe(res=>console.log(res),err=>console.log(err))
  }

  async FullLessonOfSubscriptionMenue(LessonKind:string,SubscreptionId:number)
  {
    this.SubsctiptionId=SubscreptionId;
    this.LessonOfSubscriptionList=await this.LessonService.getLessonListByLessonKind(LessonKind).toPromise();
  }
 

  OpenParticularSubscriptionDialg(): void {
    this.ParticularSubscription=new ParticularSubscription();
    this.ParticularSubscription.Name='';
    this.ParticularSubscription.Price;
    this.ParticularSubscription.StartDate='';
    this.ParticularSubscription.FinishDate='';
    this.ParticularSubscription.LessonKind='';
    const dialogRef = this.dialog.open(ParticularSubscriptionDialgBoxComponent, {
      width: '250px',
      data: ParticularSubscription,
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');  
      this.ParticularSubscription.Name=result.Name;
      this.ParticularSubscription.Price=result.Price;
      this.ParticularSubscription.StartDate=result.StartDate;
      this.ParticularSubscription.FinishDate=result.FinishDate;
      this.ParticularSubscription.LessonKind=result.LessonKind;    
      this.particularSubscriptionService.AddParticularSubscription(this.ParticularSubscription).subscribe(res=>console.log(res),err=>console.log(err))
   
    });
  }



  openDialog(): void {
   
    const dialogRef = this.dialog.open(DateDialogBoxComponent, {
      width: '250px',
      data: {Date:this.Date},
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.Date = result;
      this.FullSpesificLessonMenue();
      this.FullLesson=true;
    });
  }



  async FullSpesificLessonMenue()
  {
    if(this.Date)
    {
    this.LessonsList = await this.lessonService.getLessonsListBySubscriptionByStudentIdEndDate(parseInt(this.Id),this.Date).toPromise();
    if(this.LessonsList==null)this.openSnackBar("לא נימצאו שיעורים שניתן להירשם אליהם בתאריך המבוקש!!!") ;
    else{
    this.TeacherIdList=new Array<number>();
    this.LessonsList.forEach(lesson=>this.TeacherIdList.push(lesson.TeacherId));

    this.TeacherNameList = await this.teacherService.getTeacherNameList(this.TeacherIdList).toPromise();
  }
   }
  }


  EditLesson(lesson)
  {
    this.studentInLessonService.PostStudentInLessons(lesson,parseInt(this.Id),this.Date).subscribe(res=>console.log(res),err=>console.log(err));
   
    
  }

  CreateStudentInSubscription(SubsctiptionId:number)
  {
    const dialogRef = this.dialog.open(DateDialogBoxComponent, {
      width: '250px',
      data: {Date:this.Date},
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if(result!=undefined){
          this.StudentInSubscreption=new StudentInSubscription();
          this.StudentInSubscreption.StartDate= result;
          this.StudentInSubscreption.FinishDate= result;
          this.StudentInSubscreption.Stop=false;
          this.StudentInSubscreption.StudentId=this.Id;
          this.StudentInSubscreption.SubscribtionId=SubsctiptionId;
          this.studentInSubscriptionService.CreateStudentInSubscription(this.StudentInSubscreption)
        .subscribe((res)=>{console.log(res);
        if(res==false)this.openSnackBar('!!! לא ניתן ליצור מנוי זה, מאחר וכבר קיים מנוי אחר בתאריך המבוקש');},
        (err)=>{console.log(err);})
      }
      else
      this.openSnackBar('!!! לא הוגדר תאריך');
    });
  }

  openSnackBar(messege:string) {
    this._snackBar.open(messege, 'X', {
      horizontalPosition: this.horizontalPosition,
      verticalPosition: this.verticalPosition,
    });
  }




  CreateStudentInLesson(LessonId:number)
  {

    this.studentInLessonService.CreateLessonListByDate(this.Id,LessonId,this.Date).subscribe((res)=>{console.log(res.toString());
      if(res!=ExceptionsEnum.True)this.openSnackBar("!!! לא ניתן לקבוע שיעור זה, מאחר ומספר השיעורים הקבועים עובר את התואם למנוי זה ");},
      (err)=>{console.log(err);});
   
    console.log('create');
  }



  StopStudentInSubscription()
  {
  const dialogRef = this.dialog.open(DateDialogBoxComponent, {
    width: '250px',
    data: {Date:this.Date},
  });
  dialogRef.afterClosed().subscribe(result => {
    console.log('The dialog was closed');
    if(result!=undefined)
    this.studentInSubscriptionService.StopSubscriptionByDate(result).subscribe(res=>console.log(res.toString()));
    else
    this.openSnackBar('!!! לא הוגדר תאריך');
  });
}


}

