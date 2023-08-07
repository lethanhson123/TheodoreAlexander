import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { TaNgZorroAntdModule } from './ng-zorro-antd.module';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { HR_Recruitment_CareerService } from './shared/HR_Recruitment_Career.service';
import { HR_Recruitment_IntroduceService } from './shared/HR_Recruitment_Introduce.service';
import { LoadingComponent } from './loading/loading.component';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { en_US } from 'ng-zorro-antd/i18n';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { CareerComponent } from './career/career.component';
import { RecruitmentComponent } from './recruitment/recruitment.component';
import { CareerEnglishComponent } from './career-english/career-english.component';
import { RecruitmentEnglishComponent } from './recruitment-english/recruitment-english.component';
import { RecommendComponent } from './recommend/recommend.component';
import { RecommendEnglishComponent } from './recommend-english/recommend-english.component';
import { RecommenderComponent } from './recommender/recommender.component';
import { JobDescriptionComponent } from './job-description/job-description.component';

registerLocaleData(en);

@NgModule({
  declarations: [
    AppComponent,
    LoadingComponent,
    CareerComponent, 
    RecruitmentComponent, CareerEnglishComponent, RecruitmentEnglishComponent, RecommendComponent, RecommendEnglishComponent, RecommenderComponent, JobDescriptionComponent,    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'serverApp' }),
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    TaNgZorroAntdModule,
  ],
  providers: [
    HR_Recruitment_CareerService,
    HR_Recruitment_IntroduceService,
    {provide: MAT_DATE_LOCALE, useValue: 'en-GB'},
    { provide: NZ_I18N, useValue: en_US }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
