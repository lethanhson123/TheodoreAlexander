import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CareerEnglishComponent } from './career-english/career-english.component';
import { CareerComponent } from './career/career.component';
import { JobDescriptionComponent } from './job-description/job-description.component';
import { RecommendEnglishComponent } from './recommend-english/recommend-english.component';
import { RecommendComponent } from './recommend/recommend.component';
import { RecommenderComponent } from './recommender/recommender.component';
import { RecruitmentEnglishComponent } from './recruitment-english/recruitment-english.component';
import { RecruitmentComponent } from './recruitment/recruitment.component';

const routes: Routes = [
  { path: '', redirectTo: '/tuyen-dung', pathMatch: 'full' },  
  {
    path: 'tuyen-dung', component: CareerComponent,
  },
  {
    path: 'career', component: CareerEnglishComponent,
  },
  {
    path: 'ung-vien', component: RecruitmentComponent,
  },
  {
    path: 'recruitment', component: RecruitmentEnglishComponent,
  },
  {
    path: 'nguoi-gioi-thieu', component: RecommendComponent,
  },
  {
    path: 'recommend', component: RecommendEnglishComponent,
  },
  {
    path: 'detail/:phone', component: RecommenderComponent,
  },
  {
    path: 'description/:JobID', component: JobDescriptionComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true, initialNavigation: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
  
