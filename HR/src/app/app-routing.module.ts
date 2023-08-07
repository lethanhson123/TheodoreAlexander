import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HRCovidF0Component } from './hr-covid/hr-covid-f0/hr-covid-f0.component';
import { HRCovidF1Component } from './hr-covid/hr-covid-f1/hr-covid-f1.component';
import { HRCovidF2Component } from './hr-covid/hr-covid-f2/hr-covid-f2.component';
import { HRCovidComponent } from './hr-covid/hr-covid.component';
import { HREmployeeDetailComponent } from './hr-employee/hr-employee-detail/hr-employee-detail.component';
import { HREmployeeUploadComponent } from './hr-employee/hr-employee-upload/hr-employee-upload.component';
import { HREmployeeComponent } from './hr-employee/hr-employee.component';
import { HRRecruitmentCareerComponent } from './hr-recruitment-career/hr-recruitment-career.component';
import { HRRecruitmentIntroduceDetailComponent } from './hr-recruitment-introduce/hr-recruitment-introduce-detail/hr-recruitment-introduce-detail.component';
import { HRRecruitmentIntroduceComponent } from './hr-recruitment-introduce/hr-recruitment-introduce.component';
import { UserByStoreComponent } from './user-by-store/user-by-store.component';
import { UserComponent } from './user/user.component';



const routes: Routes = [
  { path: '', redirectTo: '/hr-recruitment-career', pathMatch: 'full' },  
  {
    path: 'hr-covid', component: HRCovidComponent,
  },
  {
    path: 'hr-covid-f0', component: HRCovidF0Component,
  },
  {
    path: 'hr-covid-f1', component: HRCovidF1Component,
  },
  {
    path: 'hr-covid-f2', component: HRCovidF2Component,
  },
  {
    path: 'hr-employee', component: HREmployeeComponent,
  },
  {
    path: 'hr-employee-detail/:ID', component: HREmployeeDetailComponent,
  },
  {
    path: 'hr-employee-upload', component: HREmployeeUploadComponent,
  },
  {
    path: 'hr-recruitment-career', component: HRRecruitmentCareerComponent,
  },
  {
    path: 'hr-recruitment-introduce', component: HRRecruitmentIntroduceComponent,
  },
  {
    path: 'hr-recruitment-introduce-detail/:phone', component: HRRecruitmentIntroduceDetailComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
