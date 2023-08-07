import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UploadService } from 'src/app/shared/upload.service';
import { NotificationService } from 'src/app/shared/notification.service';
@Component({
  selector: 'app-hr-employee-upload',
  templateUrl: './hr-employee-upload.component.html',
  styleUrls: ['./hr-employee-upload.component.css']
})
export class HREmployeeUploadComponent implements OnInit {

  isShowLoading: boolean = false;
  employeeExcelTemplateURL: string = environment.APIURL + environment.Download + "/" + environment.EmployeeExcelFileName;
  provinceExcelTemplateURL: string = environment.APIURL + environment.Download + "/" + environment.ProvinceExcelFileName;

  @ViewChild('uploadEmployee') uploadEmployee!: ElementRef;
  @ViewChild('uploadProvince') uploadProvince!: ElementRef;
  constructor(
    public uploadService: UploadService,
    public notificationService: NotificationService,
  ) { }

  ngOnInit(): void {
  }
  onSubmitEmployee() {
    let fileToUpload: File;
    fileToUpload = this.uploadEmployee.nativeElement.files[0];    
    this.isShowLoading = true;
    this.uploadService.postEmployeeListByExcelFile(fileToUpload).subscribe(
      data => {
        this.isShowLoading = false;
        this.notificationService.success(environment.UploadSuccess);
      },
      err => {
        this.isShowLoading = false;
        this.notificationService.warn(environment.UploadNotSuccess);
      }
    );
  }
  onSubmitProvince() {
    let fileToUpload: File;
    fileToUpload = this.uploadProvince.nativeElement.files[0];    
    this.isShowLoading = true;
    this.uploadService.postProvinceAndDistrictAndWardListByExcelFile(fileToUpload).subscribe(
      data => {
        this.isShowLoading = false;
        this.notificationService.success(environment.UploadSuccess);
      },
      err => {
        this.isShowLoading = false;
        this.notificationService.warn(environment.UploadNotSuccess);
      }
    );
  }
}
