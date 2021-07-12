
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
import { SubscriptionsOfStudentsDetailsComponent } from './Components/subscriptions-of-students-details/subscriptions-of-students-details.component';
import { TeachersListComponent } from './Components/teachers-list/teachers-list.component';
import { EmployeesComponent } from './Components/employees/employees.component';
import { TeacherDetailsComponent } from './Components/teacher-details/teacher-details.component';
import { LessonComponent } from './Components/lesson/lesson.component';
import { LessonsListComponent } from './Components/lessons-list/lessons-list.component';
import { LessonDetailsComponent } from './Components/lesson-details/lesson-details.component';
import { SubscreptionComponent } from './Components/subscreption/subscreption.component';
import { SubscreptionDetailsComponent } from './Components/subscreption-details/subscreption-details.component';
import { SubscreptionsListComponent } from './Components/subscreptions-list/subscreptions-list.component';
import { PaymentDetailsComponent } from './Components/payment-details/payment-details.component';
import { WeekDetailsComponent } from './Components/week-details/week-details.component';
import { AddPaymentListComponent } from './Components/add-payment-list/add-payment-list.component';




const routes: Routes = [
 
{ path: 'customers', component: CustomersComponent,
  children:
  [
    { path: 'students-list/:StudentKind', component: StudentsListComponent ,
     children: 
      [
        { path: 'edit-user/:Id', component: EditStudentDetailsComponent ,outlet: 'studentOptionsRouterOutlet'},
        { path: 'student-details/:Id', component: StudentDetailsComponent ,outlet: 'studentOptionsRouterOutlet'},
        
        { path: 'student-pay-details/:Id', component: StudentPayDetailsComponent ,outlet: 'studentOptionsRouterOutlet',
          children: 
          [
            { path: 'edit-payment', component: PaymentDetailsComponent},
          ]
      },
        { path: 'student-scadul/:Id', component: StudentScadulComponent ,outlet: 'studentOptionsRouterOutlet'},
        { path: 'student-attendance-scadul/:Id', component: StudentAttendanceScadulComponent ,outlet: 'studentOptionsRouterOutlet'},
        { path: 'student-files/:Id', component: StudentsFilesComponent ,outlet: 'studentOptionsRouterOutlet'},
        { path: 'log-in', component: LogInComponent ,outlet: 'studentOptionsRouterOutlet'},
      ]
    }, 
    {  path: 'subscriptions-of-students-details/:StudentKind', component: SubscriptionsOfStudentsDetailsComponent,
      children: 
      [
        { path: 'edit-week/:Id', component: WeekDetailsComponent ,outlet: 'studentOptionsRouterOutlet'},
      ]
    } ,  
  ]
},
{ path: 'employees', component:EmployeesComponent ,
  children:
  [
    { path: 'teachers-list', component: TeachersListComponent ,
     children: 
      [
        { path: 'edit-teacher/:Id', component: TeacherDetailsComponent ,outlet: 'teacherOptionsRouterOutlet'},       
      ]
    },      
  ]
},
{ path: 'lesson', component:LessonComponent ,
  children:
  [
    { path: 'lessons-list', component: LessonsListComponent ,
     children: 
      [
        { path: 'edit-lesson/:Id', component: LessonDetailsComponent ,outlet: 'lessonOptionsRouterOutlet'},       
      ]
    },      
  ]
},

{ path: 'subscreption', component:SubscreptionComponent ,
  children:
  [
    { path: 'subscreptions-list', component: SubscreptionsListComponent ,
     children: 
      [
        { path: 'edit-subscreption/:Id', component: SubscreptionDetailsComponent ,outlet: 'subscriptionOptionsRouterOutlet'},       
      ]
    },      
  ]
},   
 

{ path: 'add-payment-list', component: AddPaymentListComponent}

];



@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
  
})
export class AppRoutingModule { }
