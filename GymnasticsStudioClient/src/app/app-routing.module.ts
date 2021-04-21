
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
import { CustomersComponent } from './Components/customers/customers.component';
import { ManagerComponent } from './Components/manager/manager.component';
import { StudentsFilesComponent } from './Components/students-files/students-files.component';
import { EditStudentDetailsComponent } from './Components/edit-student-details/edit-student-details.component';




const routes: Routes = [
 
{ path: 'customers', component: CustomersComponent,
children:[{ path: 'students-list/:StudentKind', component: StudentsListComponent ,
     children: [
                { path: 'edit-user/:Id', component: EditStudentDetailsComponent ,outlet: 'studentOptionsRouterOutlet'},
                { path: 'student-details/:Id', component: StudentDetailsComponent ,outlet: 'studentOptionsRouterOutlet'},
                { path: 'student-pay-details/:Id', component: StudentPayDetailsComponent ,outlet: 'studentOptionsRouterOutlet'},
                { path: 'student-scadul/:Id', component: StudentScadulComponent ,outlet: 'studentOptionsRouterOutlet'},
                { path: 'student-attendance-scadul/:Id', component: StudentAttendanceScadulComponent ,outlet: 'studentOptionsRouterOutlet'},
                { path: 'student-files/:Id', component: StudentsFilesComponent ,outlet: 'studentOptionsRouterOutlet'},
                { path: 'log-in', component: LogInComponent ,outlet: 'studentOptionsRouterOutlet'},]
                
              }, 
]},
{ path: 'manager', component: ManagerComponent},
{ path: 'edit-user/:Id', component: EditStudentDetailsComponent },
];



@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
  
})
export class AppRoutingModule { }
