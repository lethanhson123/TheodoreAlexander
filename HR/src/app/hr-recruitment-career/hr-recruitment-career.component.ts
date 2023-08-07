import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HR_Recruitment_Career } from 'src/app/shared/HR_Recruitment_Career.model';
import { HR_Recruitment_CareerService } from 'src/app/shared/HR_Recruitment_Career.service';
import { DownloadService } from 'src/app/shared/download.service';
import { NotificationService } from 'src/app/shared/notification.service';
@Component({
  selector: 'app-hr-recruitment-career',
  templateUrl: './hr-recruitment-career.component.html',
  styleUrls: ['./hr-recruitment-career.component.css']
})
export class HRRecruitmentCareerComponent implements OnInit {

  isShowLoading: boolean = false;  
  searchString: string = environment.InitializationString;
  constructor(
    public hR_Recruitment_CareerService: HR_Recruitment_CareerService,    
    public downloadService: DownloadService,
    public notificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {
    this.hR_Recruitment_CareerService.getBySearchStringToList(this.searchString).then(res => {
      this.hR_Recruitment_CareerService.list = res as HR_Recruitment_Career[];     
    });
  }
  onSearch() {
    this.getToList();
  }
  onDownloadExcelFile() {
    this.isShowLoading = true;  
    this.downloadService.getHR_Recruitment_CareerBySearchStringToExcel(this.searchString).then(
      res => {
        window.location.href = res.toString();      
        this.isShowLoading = false;
      }
    );
  }
  onPrint() {
    this.isShowLoading = true;  
    this.downloadService.getHR_Recruitment_CareerBySearchStringToHTML(this.searchString).then(
      res => {
        window.location.href = res.toString();      
        this.isShowLoading = false;
      }
    );  
  }
  onSendMail(ID: any){
    this.isShowLoading = true;
    this.hR_Recruitment_CareerService.asyncSendMailByIDAny(ID).then(
      res => {
        this.isShowLoading = false;
        this.notificationService.success(environment.SendMailSuccess);                
      },
      err => {
        this.isShowLoading = false;
        this.notificationService.warn(environment.SendMailNotSuccess);        
      }                 
    );
  }
}
