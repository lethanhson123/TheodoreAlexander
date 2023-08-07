import { CommonModule } from '@angular/common';
import { Component, NgModule, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router, NavigationEnd } from '@angular/router';
import { HR_Recruitment_Introduce } from 'src/app/shared/HR_Recruitment_Introduce.model';
import { HR_Recruitment_IntroduceService } from 'src/app/shared/HR_Recruitment_Introduce.service';
import { HR_Recruitment_Career } from 'src/app/shared/HR_Recruitment_Career.model';
import { HR_Recruitment_CareerService } from 'src/app/shared/HR_Recruitment_Career.service';

@Component({
  selector: 'app-recommender',
  templateUrl: './recommender.component.html',
  styleUrls: ['./recommender.component.scss']
})
export class RecommenderComponent implements OnInit {

  listHR_Recruitment_Career: HR_Recruitment_Career[];
  constructor(private router: Router,
    public hR_Recruitment_CareerService: HR_Recruitment_CareerService,
    public hR_Recruitment_IntroduceService: HR_Recruitment_IntroduceService) {    
      this.getByPhoneQueryString();
  }

  ngOnInit() {
    
  }
  getByPhoneQueryString(){
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        let phone = event.url;
        phone = phone.split('/')[phone.split('/').length - 1];               
        this.hR_Recruitment_IntroduceService.getByPhone(phone).then(res => {
          this.hR_Recruitment_IntroduceService.formData = res as HR_Recruitment_Introduce;             
        });
        this.hR_Recruitment_CareerService.getByRecommendPhoneToList(phone).then(res => {
          this.listHR_Recruitment_Career = (res as HR_Recruitment_Career[]);      
        });        
      }
    });
  }

}
