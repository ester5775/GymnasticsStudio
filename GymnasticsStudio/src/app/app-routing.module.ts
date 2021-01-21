import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { LogInComponent } from './Components/log-in/log-in.component';
import { StudentsListComponent } from './Components/students-list/students-list.component';
import { StudentDetailsComponent } from './Components/student-details/student-details.component';
import { StudentPayDetailsComponent } from './Components/student-pay-details/student-pay-details.component';


const routes: Routes = [
  
  { path: 'log-in', component: LogInComponent },
  { path: 'students-list', component: StudentsListComponent ,
  children: [ 
    { path: 'student-details', component: StudentDetailsComponent ,outlet: 'studentDetailsRouterOutlet'},
    { path: 'student-pay-details', component: StudentPayDetailsComponent ,outlet: 'studentPayDetailsRouterOutlet'},
   
  ]
  },
  
];


@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
  
})
export class AppRoutingModule { }
