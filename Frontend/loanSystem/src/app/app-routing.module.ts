import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListUserComponent } from './list-user/list-user.component';
import { LoanApplicationComponent } from './loan-application/loan-application.component';
import { LoanRequestFormComponent } from './loan-request-form/loan-request-form.component';
import { AdminComponent } from './admin/admin.component';
import { ListLoanApplicationComponent } from './list-loan-application/list-loan-application.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { LoanListUserComponent } from './loan-list-user/loan-list-user.component';
import { ChangePasswordComponent } from './change-password/change-password.component';

const routes: Routes = [
  {path:'',pathMatch:'full',redirectTo:'login'},
  {path:'login',component:LoginComponent},
  {path:'register',component:RegisterComponent},
  {path:'changePassword',component:ChangePasswordComponent},
  {path:'loanApplication',component:LoanApplicationComponent},
  {path : 'users', component: ListUserComponent}
  ,{path : 'adduser', component: LoanRequestFormComponent},
  {path: 'admin',component: AdminComponent},
  {path: 'admin/loanrequestList',component: ListLoanApplicationComponent},
  {path: 'loans',component:LoanListUserComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
