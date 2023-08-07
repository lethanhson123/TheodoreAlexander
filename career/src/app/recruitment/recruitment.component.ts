import { CommonModule } from '@angular/common';
import { Component, NgModule, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzModalRef } from 'ng-zorro-antd/modal';
import { TaNgZorroAntdModule } from 'src/app/ng-zorro-antd.module';
import { NgForm } from '@angular/forms';
import { HR_Recruitment_Career } from 'src/app/shared/HR_Recruitment_Career.model';
import { HR_Recruitment_CareerService } from 'src/app/shared/HR_Recruitment_Career.service';

@Component({
  selector: 'app-recruitment',
  templateUrl: './recruitment.component.html',
  styleUrls: ['./recruitment.component.scss']
})
export class RecruitmentComponent implements OnInit {

  isVisibleThankPopup: boolean;
  isSubmit: boolean;
  fullNameError: string;
  phoneError: string;
  constructor(
    public hR_Recruitment_CareerService: HR_Recruitment_CareerService,
  ) {
    this.hR_Recruitment_CareerService.getByID(0).then(res => {
      this.hR_Recruitment_CareerService.formData = res as HR_Recruitment_Career;
    });
  }

  ngOnInit() {
  }
  onSubmit() {
    this.onCheckSubmit();    
    if (this.isSubmit == true) {
      this.onOpenApply(true);
      this.hR_Recruitment_CareerService.asyncAdd(this.hR_Recruitment_CareerService.formData).subscribe(
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
    this.fullNameError = "Vui lòng nhập họ tên của bạn";
    if (this.hR_Recruitment_CareerService.formData.FullName != null) {
      if (this.hR_Recruitment_CareerService.formData.FullName.length > 0) {
        this.fullNameError = "";
        checkSubmit = checkSubmit + 1;
      }      
    }
    
    this.phoneError = "Vui lòng nhập điện thoại của bạn";
    if (this.hR_Recruitment_CareerService.formData.Phone != null) {
      if (this.hR_Recruitment_CareerService.formData.Phone.length > 0) {
        this.phoneError = "";
        checkSubmit = checkSubmit + 1;
      }    
    }
    if (checkSubmit == 2) {
      this.isSubmit = true;
    }
  }
}
