import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router, NavigationEnd } from '@angular/router';
import { HR_Recruitment_Introduce } from 'src/app/shared/HR_Recruitment_Introduce.model';
import { HR_Recruitment_IntroduceService } from 'src/app/shared/HR_Recruitment_Introduce.service';
import { HR_Recruitment_Career } from 'src/app/shared/HR_Recruitment_Career.model';
import { HR_Recruitment_CareerService } from 'src/app/shared/HR_Recruitment_Career.service';
import { DownloadService } from 'src/app/shared/download.service';
@Component({
  selector: 'app-hr-recruitment-introduce-detail',
  templateUrl: './hr-recruitment-introduce-detail.component.html',
  styleUrls: ['./hr-recruitment-introduce-detail.component.css']
})
export class HRRecruitmentIntroduceDetailComponent implements OnInit {

  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  searchString: string = environment.InitializationString;
  fullName: string = environment.InitializationString;
  phone: string = environment.InitializationString;
  bankID: string = environment.InitializationString;
  bankName: string = environment.InitializationString;
  constructor(
    private router: Router,
    public hR_Recruitment_CareerService: HR_Recruitment_CareerService,
    public hR_Recruitment_IntroduceService: HR_Recruitment_IntroduceService,
    public downloadService: DownloadService,
  ) {
    this.getByQueryString();
  }

  ngOnInit(): void {
  }
  getByQueryString() {
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        this.queryString = event.url;
        this.queryString = this.queryString.split('/')[this.queryString.split('/').length - 1];
        this.hR_Recruitment_IntroduceService.getByPhone(this.queryString).then(res => {
          this.hR_Recruitment_IntroduceService.formData = res as HR_Recruitment_Introduce;
        });
        this.hR_Recruitment_CareerService.getByRecommendPhoneAndSearchStringToList(this.queryString, this.searchString).then(res => {
          this.hR_Recruitment_CareerService.list = res as HR_Recruitment_Career[];
        });
      }
    });
  }
  onSearch() {
    this.hR_Recruitment_CareerService.getByRecommendPhoneAndSearchStringToList(this.queryString, this.searchString).then(res => {
      this.hR_Recruitment_CareerService.list = res as HR_Recruitment_Career[];
    });
  }
  onDownloadExcelFile() {
    this.isShowLoading = true;
    this.downloadService.getHR_Recruitment_CareerByRecommendPhoneAndSearchStringToExcel(this.queryString, this.searchString).then(
      res => {
        window.open(res.toString(), "_blank");
        this.isShowLoading = false;
      }
    );
  }
  onPrint() {
    this.isShowLoading = true;
    this.downloadService.getHR_Recruitment_CareerByRecommendPhoneAndSearchStringToHTML(this.queryString, this.searchString).then(
      res => {
        window.open(res.toString(), "_blank");
        this.isShowLoading = false;
      }
    );
  }
}
