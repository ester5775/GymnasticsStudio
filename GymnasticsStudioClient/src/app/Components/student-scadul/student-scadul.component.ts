import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Lesson } from 'src/app/classes/lesson';
import { StudentInSubscription } from 'src/app/classes/student-in-subscription';
import { Subscription } from 'src/app/classes/subscription';
import { StudentInSubscriptionService } from 'src/app/Services/student-in-subscription.service';
import { StudentService } from 'src/app/Services/student.service';
import { SubscriptionService } from 'src/app/Services/subscription.service';

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
  WeekNum:number;
  Balance:number;
  status:string="זכות";
  constructor(private route: ActivatedRoute,private studentInSubscriptionService:StudentInSubscriptionService,
    private studentService:StudentService,private subscriptionService:SubscriptionService) {
    
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

  async FullMenue()
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
}




