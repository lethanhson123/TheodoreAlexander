import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { HR_CovidService } from 'src/app/shared/HR_Covid.service';
import { HR_Employee } from 'src/app/shared/HR_Employee.model';
import { HR_EmployeeDataTransfer001 } from 'src/app/shared/HR_EmployeeDataTransfer001.model';
import { HR_EmployeeService } from 'src/app/shared/HR_Employee.service';
import { HR_CovidLocal } from 'src/app/shared/HR_CovidLocal.model';
import { HR_CovidLocalService } from 'src/app/shared/HR_CovidLocal.service';
import { HR_CovidResult } from 'src/app/shared/HR_CovidResult.model';
import { HR_CovidResultService } from 'src/app/shared/HR_CovidResult.service';
import { HR_CovidTest } from 'src/app/shared/HR_CovidTest.model';
import { HR_CovidTestService } from 'src/app/shared/HR_CovidTest.service';
import { HR_CovidType } from 'src/app/shared/HR_CovidType.model';
import { HR_CovidTypeService } from 'src/app/shared/HR_CovidType.service';
import { HR_Covid } from 'src/app/shared/HR_Covid.model';
import { HR_Province } from 'src/app/shared/HR_Province.model';
import { HR_ProvinceService } from 'src/app/shared/HR_Province.service';
import { HR_District } from 'src/app/shared/HR_District.model';
import { HR_DistrictService } from 'src/app/shared/HR_District.service';
import { HR_Ward } from 'src/app/shared/HR_Ward.model';
import { HR_WardService } from 'src/app/shared/HR_Ward.service';

@Component({
  selector: 'app-hr-covid-detail',
  templateUrl: './hr-covid-detail.component.html',
  styleUrls: ['./hr-covid-detail.component.css']
})
export class HRCovidDetailComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  employeeSearchString: string = environment.InitializationString;
  ID: number = environment.InitializationNumber;
  constructor(public hR_CovidService: HR_CovidService,
    public hR_EmployeeService: HR_EmployeeService,
    public hR_CovidLocalService: HR_CovidLocalService,
    public hR_CovidResultService: HR_CovidResultService,
    public hR_CovidTestService: HR_CovidTestService,
    public hR_CovidTypeService: HR_CovidTypeService,
    public hR_ProvinceService: HR_ProvinceService,
    public hR_DistrictService: HR_DistrictService,
    public hR_WardService: HR_WardService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<HRCovidDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.ID = data["ID"] as number;
  }

  ngOnInit(): void {
    this.getHR_EmployeeDataTransferToList(this.searchString);
    this.getHR_CovidLocalAllToList();
    this.getHR_CovidResultAllToList();
    this.getHR_CovidTestAllToList();
    this.getHR_CovidTypeAllToList();
    this.getCodeManageToList();
    this.getHR_ProvinceBySearchStringToList(this.searchString);
    this.getHR_DistrictByParentIDToList();
    this.getHR_WardByParentIDToList();
  }
  onClose() {
    this.hR_CovidService.initializationFormData();
    this.dialogRef.close();
  }
  getHR_EmployeeDataTransferToList(searchString: string) {   
      this.hR_EmployeeService.getDataTransfer001BySearchStringAndIDToList(searchString, this.ID).then(res => {
        this.hR_EmployeeService.listHR_EmployeeDataTransfer = res as HR_EmployeeDataTransfer001[];
      });    
  }
  getHR_CovidLocalAllToList() {
    this.hR_CovidLocalService.getAllToList().then(res => {
      this.hR_CovidLocalService.list = res as HR_CovidLocal[];
    });
  }
  getHR_CovidResultAllToList() {
    this.hR_CovidResultService.getAllToList().then(res => {
      this.hR_CovidResultService.list = res as HR_CovidResult[];
    });
  }
  getHR_CovidTestAllToList() {
    this.hR_CovidTestService.getAllToList().then(res => {
      this.hR_CovidTestService.list = res as HR_CovidTest[];
    });
  }
  getHR_CovidTypeAllToList() {
    this.hR_CovidTypeService.getAllToList().then(res => {
      this.hR_CovidTypeService.list = res as HR_CovidType[];
    });
  }
  getCodeManageToList() {
    this.hR_CovidService.getByWithCodeManageToList().then(res => {
      this.hR_CovidService.listWithCodeManage = res as HR_Covid[];
    });
  }
  onFilterHR_EmployeeDataTrans(event: Event) {
    let searchString: string = (event.target as HTMLInputElement).value;    
    this.getHR_EmployeeDataTransferToList(searchString);
  }
  onChangeEmployee() {
    this.hR_EmployeeService.getByID(this.hR_CovidService.formData.EmployeeID).then(res => {
      this.hR_EmployeeService.formData = res as HR_Employee;
      this.hR_CovidService.formData.AddressContact = this.hR_EmployeeService.formData.AddressContact;
    });
  }
  getHR_ProvinceBySearchStringToList(searchString: string) {
    this.hR_ProvinceService.getBySearchStringToList(searchString).then(res => {
      this.hR_ProvinceService.list = res as HR_Province[];
    });
  }
  onFilterProvince(event: Event) {
    let searchString: string = (event.target as HTMLInputElement).value;
    this.getHR_ProvinceBySearchStringToList(searchString);
  }
  onChangeIsolationProvince() {
    this.getHR_DistrictByParentIDToList();
  }
  onChangeIsolationDistrict() {
    this.getHR_WardByParentIDToList();
  }
  getHR_DistrictByParentIDToList() {
    this.hR_DistrictService.getByParentIDToList(this.hR_CovidService.formData.IsolationProvinceID).then(res => {
      this.hR_DistrictService.list = res as HR_District[];
    });
  }
  getHR_WardByParentIDToList() {
    this.hR_WardService.getByParentIDToList(this.hR_CovidService.formData.IsolationDistrictID).then(res => {
      this.hR_WardService.list = res as HR_Ward[];
    });
  }
  onSubmit(form: NgForm) {
    this.hR_CovidService.add(form.value).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.onClose();
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.onClose();
      }
    );
  }
}

