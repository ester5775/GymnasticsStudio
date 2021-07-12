import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'src/app/classes/subscription';
import { SubscriptionService } from 'src/app/Services/subscription.service';


@Component({
  selector: 'app-subscreptions-list',
  templateUrl: './subscreptions-list.component.html',
  styleUrls: ['./subscreptions-list.component.css']
})
export class SubscreptionsListComponent implements OnInit {

   
  displayedColumns: string[] = ['Name','Price'];  
  SubscriptionList:Array<Subscription>;
  student:Subscription;
  SearchForm:FormGroup;
  constructor(private route: ActivatedRoute,private router: Router, private SubscriptionService:SubscriptionService,private formBuilder: FormBuilder) {
   
   }

   ngOnInit(): void {
    
    this.GetSubscriptionList();
   
    this.SearchForm = this.formBuilder.group({
      Name:[''],
      Price:[''],          
    });
    
  }

 

  GetSubscriptionList()
  {
    
    this.SubscriptionService.getSubscriptionList()
      .subscribe(SubscriptionList => {
        this.SubscriptionList=SubscriptionList;
      });
  }

 

  OpenSubscriptionDetails(SubscriptionId:number){
    
   // this.student=element;
    this.router.navigateByUrl("subscreption/subscreptions-list/(subscriptionOptionsRouterOutlet:edit-subscreption/"+SubscriptionId+")");
  }


 
   
  AddSubscription(){
    
    this.router.navigateByUrl("subscreption/subscreptions-list/(subscriptionOptionsRouterOutlet:edit-subscreption/0");
  }


  

}
  