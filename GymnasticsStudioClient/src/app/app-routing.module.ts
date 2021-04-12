import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { LogInComponent } from './Components/log-in/log-in.component';
import { StudentsListComponent } from './Components/students-list/students-list.component';
import { StudentDetailsComponent } from './Components/student-details/student-details.component';
import { StudentPayDetailsComponent } from './Components/student-pay-details/student-pay-details.component';
import { StudentScadulComponent } from './Components/student-scadul/student-scadul.component';
import { StudentAttendanceScadulComponent } from './Components/student-attendance-scadul/student-attendance-scadul.component';
import { EditStudentDetailsComponent } from './Components/edit-student-details/edit-student-details.component';
import {
  MatCardModule,
} from "@angular/material/card";
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


const routes: Routes = [
  { path: 'edit-user/:id', component: EditStudentDetailsComponent},
  { path: 'log-in', component: LogInComponent },
  { path: 'students-list', component: StudentsListComponent ,
     children: [{ path: 'student-details/:Id', component: StudentDetailsComponent ,outlet: 'studentOptionsRouterOutlet'},
                { path: 'student-pay-details/:Id', component: StudentPayDetailsComponent ,outlet: 'studentOptionsRouterOutlet'},
                { path: 'student-scadul/:Id', component: StudentScadulComponent ,outlet: 'studentOptionsRouterOutlet'},
                { path: 'student-attendance-scadul/:Id', component: StudentAttendanceScadulComponent ,outlet: 'studentOptionsRouterOutlet'},]
              }, 
];


@NgModule({
  declarations: [],
imports:[[RouterModule.forRoot(routes)]],
  exports: [RouterModule]
  
})
export class AppRoutingModule { }
