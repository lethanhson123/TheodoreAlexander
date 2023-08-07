import { Component, OnInit, ViewChild } from '@angular/core';
import { HR_Recruitment_Introduce } from 'src/app/shared/HR_Recruitment_Introduce.model';
import { HR_Recruitment_IntroduceService } from 'src/app/shared/HR_Recruitment_Introduce.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { DownloadService } from 'src/app/shared/download.service';
@Component({
  selector: 'app-hr-recruitment-introduce',
  templateUrl: './hr-recruitment-introduce.component.html',
  styleUrls: ['./hr-recruitment-introduce.component.css']
})
export class HRRecruitmentIntroduceComponent implements OnInit {

  isShowLoading: boolean = false;
  dataSource: MatTableDataSource<any> | undefined;
  displayColumns: string[] = ['FullName', 'Phone', 'BankID', 'BankName'];
  searchString: string = environment.InitializationString;
  @ViewChild(MatSort) sort: MatSort | undefined;
  @ViewChild(MatPaginator) paginator: MatPaginator | undefined;
  constructor(
    public hR_Recruitment_IntroduceService: HR_Recruitment_IntroduceService,
    public downloadService: DownloadService,
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {
    this.hR_Recruitment_IntroduceService.getBySearchStringToList(this.searchString).then(res => {
      this.hR_Recruitment_IntroduceService.list = res as HR_Recruitment_Introduce[];     
    });
  }
  onSearch() {
    this.getToList();
  }
  onDownloadExcelFile() {
    this.isShowLoading = true;  
    this.downloadService.getHR_Recruitment_IntroduceBySearchStringToExcel(this.searchString).then(
      res => {
        window.location.href = res.toString();      
        this.isShowLoading = false;
      }
    );
  }
  onPrint() {
    this.isShowLoading = true;  
    this.downloadService.getHR_Recruitment_IntroduceBySearchStringToHTML(this.searchString).then(
      res => {
        window.location.href = res.toString();      
        this.isShowLoading = false;
      }
    );  
  }
}
