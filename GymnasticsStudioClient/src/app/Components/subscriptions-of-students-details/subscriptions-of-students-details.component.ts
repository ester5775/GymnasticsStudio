import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Student } from 'src/app/classes/student';
import { StudentInSubscripyionDetails } from 'src/app/classes/student-in-subscripyion-details';
import { StudentInSubscripyionDetailsList } from 'src/app/classes/student-in-subscripyion-details-list';
import { StudentInLessonService } from 'src/app/Services/student-in-lesson.service';
import { StudentInSubscriptionDetailsService } from 'src/app/Services/student-in-subscription-details.service';
import { StudentService } from 'src/app/Services/student.service';

@Component({
  selector: 'app-subscriptions-of-students-details',
  templateUrl: './subscriptions-of-students-details.component.html',
  styleUrls: ['./subscriptions-of-students-details.component.css']
})
export class SubscriptionsOfStudentsDetailsComponent implements OnInit {

  constructor(private route: ActivatedRoute,
    private studentInSubscriptionDetailsService:StudentInSubscriptionDetailsService,
    private studentInLessonService:StudentInLessonService,
    private router: Router,
    ) { }


  studentsKind:string;
  studentInSubscriptionDetailsList:Array<StudentInSubscripyionDetailsList>;
  displayedColumns1: string[]=[];
  displayedColumns: string[] = ['Date','Lesson','Attendence','Subscription','Payment'];
  showTable:boolean=false;
  panelOpenState:boolean = false;
  lastWeekId:number=-1;
  pRowSpan:number=1;
  pCorrIndex:number=0;
  sRowSpan:number=1;
  sCorrIndex:number=0;
  dRowSpan:number=1;
  dCorrIndex:number=0;


  ngOnInit(): void {
    this.studentsKind=this.route.snapshot.paramMap.get('StudentKind');
    this.GetStudentInSubscriptionDetailsListListBystudentKind(this.studentsKind);
   
  }

  GetStudentInSubscriptionDetailsListListBystudentKind(studentsKind:string)
  {
    
    this.studentInSubscriptionDetailsService.getStudentInSubscriptionDetailsListListBystudentKind(studentsKind)
      .subscribe(studentInSubscriptionDetailsService => {
        this.studentInSubscriptionDetailsList=studentInSubscriptionDetailsService;
        this.showTable=true;
        this.studentInSubscriptionDetailsList.forEach(element => {
          this.displayedColumns1.push(element.StudentName);
        });
      });
     
    }
    // getDRowSpan(index:number)
    // {
      
    //   this.dRowSpan=0;
    //   var dataSorce=this.studentInSubscriptionDetailsList[0].studentInSubscriptionDetailsDTOList;
    //   var i:number=index;
    //   while (dataSorce[i]&&dataSorce[i].WeehId==dataSorce[index].WeehId) {
    //     this.dRowSpan++;
    //     i++;
    //   }
    //   if(i==index+1)
    //   this.dCorrIndex=index;
    //   return this.dRowSpan;
    // }

    // getSRowSpan(index:number)
    // {
      
    //   this.sRowSpan=0;
    //   var dataSorce=this.studentInSubscriptionDetailsList[0].studentInSubscriptionDetailsDTOList;
    //   var i:number=index;
    //   while (dataSorce[i]&&dataSorce[i].SubscriptionId==dataSorce[index].SubscriptionId) {
    //     this.sRowSpan++;
    //     i++;
    //   }
    //   if(i==index+1)
    //    this.sCorrIndex=index;
    //   return this.sRowSpan;
    // }

    // getPRowSpan(index:number)
    // {
    //   if(this.pRowSpan!=1)
    //   {
    //     this.pRowSpan--;
    //     return this.pRowSpan;
    //   }         
    //   this.pRowSpan=0;
    //   var dataSorce=this.studentInSubscriptionDetailsList[0].studentInSubscriptionDetailsDTOList;
    //   var i:number=index;
    //   while (dataSorce[i]&&dataSorce[i].PaymentId==dataSorce[index].PaymentId) {
    //     this.pRowSpan++;
    //     i++;
    //   }
    //    this.pCorrIndex=index;
    //   return this.pRowSpan;
    // }

    UpdateAttendence(attendence:boolean,studentInSubscripyionDetails:StudentInSubscripyionDetails)
    {
      
      this.studentInLessonService.UpdateAttendence(studentInSubscripyionDetails.StudentInLessonId,attendence).subscribe(res => console.log(res), err => console.log(err))
  
    }

    OpenWeekDetails(studentInSubscripyionDetails:StudentInSubscripyionDetails)
    {
      this.router.navigateByUrl('customers/subscriptions-of-students-details/'+this.studentsKind+'/(studentOptionsRouterOutlet:edit-week/'+studentInSubscripyionDetails.WeehId+')');
      
    }


}
