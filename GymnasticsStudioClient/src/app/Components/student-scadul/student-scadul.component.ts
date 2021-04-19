import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Lesson } from 'src/app/classes/lesson';
import { StudentInSubscription } from 'src/app/classes/student-in-subscription';
import { StudentInSubscriptionService } from 'src/app/Services/student-in-subscription.service';
import { StudentService } from 'src/app/Services/student.service';

@Component({
  selector: 'app-student-scadul',
  templateUrl: './student-scadul.component.html',
  styleUrls: ['./student-scadul.component.css']
})
export class StudentScadulComponent implements OnInit {

  Id;
  LessonsList:Array<Lesson>
  SubscriptionList:Subscription[];
  CurrentSubscription:Subscription;
  CurrentStudentInSubscription:StudentInSubscription;
  WeekNum:number;
  Balance:number;
  status:string="זכות";
  constructor(private route: ActivatedRoute,private studentInSubscriptionService:StudentInSubscriptionService,private studentService:StudentService) {
    
    this.Id=route.snapshot.paramMap.get('Id');}
    


  async ngOnInit(): Promise<void> {

    this.CurrentSubscription= await this.studentInSubscriptionService.getCurrentSubscription(this.Id).toPromise();
    this.WeekNum = await this.studentInSubscriptionService.getCurrentWeekNum(this.Id).toPromise();
    this.Balance= await this.studentService.getBalance(this.Id).toPromise();
    if(this.Balance<0)
    {
    status="חוב";
    }
  }

}
