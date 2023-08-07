import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { HR_Recruitment_CareerService } from './shared/HR_Recruitment_Career.service';
import { HR_Recruitment_IntroduceService } from './shared/HR_Recruitment_Introduce.service';
import { HR_BlockService } from './shared/HR_Block.service';
import { HR_DepartmentService } from './shared/HR_Department.service';
import { HR_DistrictService } from './shared/HR_District.service';
import { HR_DivisionService } from './shared/HR_Division.service';
import { HR_DutyService } from './shared/HR_Duty.service';
import { HR_Employee_HistoryWorkService } from './shared/HR_Employee_HistoryWork.service';
import { HR_EmployeeService } from './shared/HR_Employee.service';
import { HR_GroupService } from './shared/HR_Group.service';
import { HR_ProvinceService } from './shared/HR_Province.service';
import { HR_StatusService } from './shared/HR_Status.service';
import { HR_TeamService } from './shared/HR_Team.service';
import { HR_WardService } from './shared/HR_Ward.service';
import { HR_WorkingStatusService } from './shared/HR_WorkingStatus.service';
import { HR_CovidService } from './shared/HR_Covid.service';
import { HR_CovidLocalService } from './shared/HR_CovidLocal.service';
import { HR_CovidResultService } from './shared/HR_CovidResult.service';
import { HR_CovidTestService } from './shared/HR_CovidTest.service';
import { HR_CovidTypeService } from './shared/HR_CovidType.service';
import { UserService } from './shared/User.service';
import { HRRecruitmentCareerComponent } from './hr-recruitment-career/hr-recruitment-career.component';
import { HRRecruitmentIntroduceComponent } from './hr-recruitment-introduce/hr-recruitment-introduce.component';
import { LoadingComponent } from './loading/loading.component';
import { HRRecruitmentIntroduceDetailComponent } from './hr-recruitment-introduce/hr-recruitment-introduce-detail/hr-recruitment-introduce-detail.component';
import { HREmployeeComponent } from './hr-employee/hr-employee.component';
import { HREmployeeUploadComponent } from './hr-employee/hr-employee-upload/hr-employee-upload.component';
import { HRCovidComponent } from './hr-covid/hr-covid.component';
import { HRCovidDetailComponent } from './hr-covid/hr-covid-detail/hr-covid-detail.component';
import { HRCovidF0Component } from './hr-covid/hr-covid-f0/hr-covid-f0.component';
import { HRCovidF1Component } from './hr-covid/hr-covid-f1/hr-covid-f1.component';
import { HRCovidF2Component } from './hr-covid/hr-covid-f2/hr-covid-f2.component';
import { HREmployeeDetailComponent } from './hr-employee/hr-employee-detail/hr-employee-detail.component';
import { UserComponent } from './user/user.component';
import { StoreService } from './shared/Store.service';
import { UserByStoreComponent } from './user-by-store/user-by-store.component';


@NgModule({
  declarations: [
    AppComponent,    
    HRRecruitmentCareerComponent, 
    HRRecruitmentIntroduceComponent, 
    LoadingComponent, 
    HRRecruitmentIntroduceDetailComponent, 
    HREmployeeComponent, 
    HREmployeeUploadComponent, 
    HRCovidComponent, 
    HRCovidDetailComponent, 
    HRCovidF0Component, 
    HRCovidF1Component, 
    HRCovidF2Component, 
    HREmployeeDetailComponent, 
    UserComponent, UserByStoreComponent,     
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
  ],
  providers: [
    HR_Recruitment_CareerService,
    HR_Recruitment_IntroduceService,
    HR_BlockService,
    HR_DepartmentService,
    HR_DistrictService,
    HR_DivisionService,
    HR_DutyService,
    HR_Employee_HistoryWorkService,
    HR_EmployeeService,
    HR_GroupService,
    HR_ProvinceService,
    HR_StatusService,
    HR_TeamService,
    HR_WardService,
    HR_WorkingStatusService,
    HR_CovidService,
    HR_CovidLocalService,
    HR_CovidResultService,
    HR_CovidTestService,
    HR_CovidTypeService,    
    UserService,    
    StoreService,
    {provide: MAT_DATE_LOCALE, useValue: 'en-GB'}
  ],
  entryComponents: [
    HRCovidDetailComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
