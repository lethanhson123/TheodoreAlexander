import { CommonModule } from '@angular/common';
import { Component, NgModule, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzModalRef } from 'ng-zorro-antd/modal';
import { TaNgZorroAntdModule } from 'src/app/ng-zorro-antd.module';
import { NgForm } from '@angular/forms';
import { HR_Recruitment_Introduce } from 'src/app/shared/HR_Recruitment_Introduce.model';
import { HR_Recruitment_IntroduceService } from 'src/app/shared/HR_Recruitment_Introduce.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-recommend-english',
  templateUrl: './recommend-english.component.html',
  styleUrls: ['./recommend-english.component.scss']
})
export class RecommendEnglishComponent implements OnInit {

  domainName: string = environment.DomainName + "detail";
  isVisibleThankPopup: boolean;
  isSubmit: boolean;
  fullNameError: string;
  phoneError: string;
  constructor(
    public hR_Recruitment_IntroduceService: HR_Recruitment_IntroduceService,
  ) {
    this.hR_Recruitment_IntroduceService.getByID(0).then(res => {
      this.hR_Recruitment_IntroduceService.formData = res as HR_Recruitment_Introduce;
    });
  }

  ngOnInit() {
  }
  onSubmit() {
    this.onCheckSubmit();
    if (this.isSubmit == true) {
      this.onOpenApply(true);
      this.hR_Recruitment_IntroduceService.asyncAdd(this.hR_Recruitment_IntroduceService.formData).subscribe(
        res => {

        },
        err => {
        }
      );
    }
  }
  onOpenApply(view: boolean) {
    this.isVisibleThankPopup = view;
  }
  onCheckSubmit() {
    this.isSubmit = false;
    let checkSubmit = 0;
    this.fullNameError = "Please enter your name";
    if (this.hR_Recruitment_IntroduceService.formData.FullName != null) {
      if (this.hR_Recruitment_IntroduceService.formData.FullName.length > 0) {
        this.fullNameError = "";
        checkSubmit = checkSubmit + 1;
      }
    }

    this.phoneError = "Please enter your phone number";
    if (this.hR_Recruitment_IntroduceService.formData.Phone != null) {
      if (this.hR_Recruitment_IntroduceService.formData.Phone.length > 0) {
        this.phoneError = "";
        checkSubmit = checkSubmit + 1;
      }
    }
    if (checkSubmit == 2) {
      this.isSubmit = true;
    }
  }
  copyText(inputElement: any) {
    inputElement.select();
    document.execCommand('copy');
    inputElement.setSelectionRange(0, 0);
  }

}
