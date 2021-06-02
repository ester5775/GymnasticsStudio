import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Student } from 'src/app/classes/student';
import { StudentInSubscripyionDetailsList } from 'src/app/classes/student-in-subscripyion-details-list';
import { StudentInSubscriptionDetailsService } from 'src/app/Services/student-in-subscription-details.service';
import { StudentService } from 'src/app/Services/student.service';

@Component({
  selector: 'app-subscriptions-of-students-details',
  templateUrl: './subscriptions-of-students-details.component.html',
  styleUrls: ['./subscriptions-of-students-details.component.css']
})
export class SubscriptionsOfStudentsDetailsComponent implements OnInit {

  constructor(private route: ActivatedRoute,private studentInSubscriptionDetailsService:StudentInSubscriptionDetailsService,) { }


  studentsKind:string;
  studentInSubscriptionDetailsList:Array<StudentInSubscripyionDetailsList>;
  displayedColumns: string[] = ['Date','Lesson','Attendence','Subscription','Payment'];
  showTable:boolean=false;
  panelOpenState:boolean = false;
  lastWeekId:number=-1;
  pRowSpan:number=0;
  pCorrIndex:number;
  sRowSpan:number=0;
  sCorrIndex:number;
  dRowSpan:number=0;
  dCorrIndex:number;


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
      });
     
    }
    getDRowSpan(index:number)
    {
      
      this.dRowSpan=0;
      var dataSorce=this.studentInSubscriptionDetailsList[0].studentInSubscriptionDetailsDTOList;
      var i:number=index;
      while (dataSorce[i]&&dataSorce[i].WeehId==dataSorce[index].WeehId) {
        this.dRowSpan++;
        i++;
      }
      if(i==index+1)
      this.dCorrIndex=index;
      return this.dRowSpan;
    }

    getSRowSpan(index:number)
    {
      
      this.sRowSpan=0;
      var dataSorce=this.studentInSubscriptionDetailsList[0].studentInSubscriptionDetailsDTOList;
      var i:number=index;
      while (dataSorce[i]&&dataSorce[i].SubscriptionId==dataSorce[index].SubscriptionId) {
        this.sRowSpan++;
        i++;
      }
      if(i==index+1)
       this.sCorrIndex=index;
      return this.sRowSpan;
    }

    getPRowSpan(index:number)
    {
      
      this.pRowSpan=0;
      var dataSorce=this.studentInSubscriptionDetailsList[0].studentInSubscriptionDetailsDTOList;
      var i:number=index;
      while (dataSorce[i]&&dataSorce[i].PaymentId==dataSorce[index].PaymentId) {
        this.pRowSpan++;
        i++;
      }
      if(i==index+1)
       this.pCorrIndex=index;
      return this.pRowSpan;
    }




}
