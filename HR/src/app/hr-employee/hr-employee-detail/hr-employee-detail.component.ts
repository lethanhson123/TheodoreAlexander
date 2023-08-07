import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { HR_Covid } from 'src/app/shared/HR_Covid.model';
import { HR_CovidDataTransfer } from 'src/app/shared/HR_CovidDataTransfer.model';
import { HR_CovidService } from 'src/app/shared/HR_Covid.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { HRCovidDetailComponent } from 'src/app/hr-covid/hr-covid-detail/hr-covid-detail.component';
import { Router, NavigationEnd } from '@angular/router';
import { HR_Employee } from 'src/app/shared/HR_Employee.model';
import { HR_EmployeeService } from 'src/app/shared/HR_Employee.service';
import { HR_Province } from 'src/app/shared/HR_Province.model';
import { HR_ProvinceService } from 'src/app/shared/HR_Province.service';
import { HR_District } from 'src/app/shared/HR_District.model';
import { HR_DistrictService } from 'src/app/shared/HR_District.service';
import { HR_Ward } from 'src/app/shared/HR_Ward.model';
import { HR_WardService } from 'src/app/shared/HR_Ward.service';
import { NgForm } from '@angular/forms';
import {Location} from '@angular/common';

@Component({
  selector: 'app-hr-employee-detail',
  templateUrl: './hr-employee-detail.component.html',
  styleUrls: ['./hr-employee-detail.component.css']
})
export class HREmployeeDetailComponent implements OnInit {

  isShowLoading: boolean = false;
  displayColumns: string[] = ['EmployeeID'];
  searchString: string = environment.InitializationString;
  queryString: string = environment.InitializationString;
  ID: number = environment.InitializationNumber;
  constructor(
    private _location: Location,
    private router: Router,
    public hR_CovidService: HR_CovidService,
    public hR_EmployeeService: HR_EmployeeService,
    public hR_ProvinceService: HR_ProvinceService,
    public hR_DistrictService: HR_DistrictService,
    public hR_WardService: HR_WardService,
    public notificationService: NotificationService,
    private dialog: MatDialog
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
        this.ID = parseInt(this.queryString);
        this.getHR_CovidByEmployeeIDToList(this.ID);
        this.getHR_EmployeeByID(this.ID);
      }
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
  getHR_DistrictByParentIDToList() {
    this.hR_DistrictService.getByParentIDToList(this.hR_EmployeeService.formData.AddressContactProvinceID).then(res => {
      this.hR_DistrictService.list = res as HR_District[];
    });
  }
  getHR_WardByParentIDToList() {
    this.hR_WardService.getByParentIDToList(this.hR_EmployeeService.formData.AddressContactDistrictID).then(res => {
      this.hR_WardService.list = res as HR_Ward[];
    });
  }
  getHR_CovidByEmployeeIDToList(ID: number) {    
    this.hR_CovidService.getDataTransferByEmployeeIDToList(ID).then(res => {
      this.hR_CovidService.listDataTransfer = res as HR_CovidDataTransfer[];      
    });
  }
  getHR_EmployeeByID(ID: number) {    
    this.hR_EmployeeService.getByID(ID).then(res => {
      this.hR_EmployeeService.formData = res as HR_Employee;      
      this.getHR_ProvinceBySearchStringToList(this.searchString);
      this.getHR_DistrictByParentIDToList();
      this.getHR_WardByParentIDToList();
    });
  }
  onAdd(ID: any) {
    this.hR_CovidService.getByID(ID).then(res => {
      this.hR_CovidService.formData = res as HR_Covid;
    });
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;
    dialogConfig.height = "200%";
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(HRCovidDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.getHR_CovidByEmployeeIDToList(this.ID);
    });
  }
  onSubmit(form: NgForm) {    
    if (this.hR_EmployeeService.formData.ID > 0) {
      this.hR_EmployeeService.update(form.value).subscribe(
        res => {
          this.notificationService.success(environment.SaveSuccess);          
        },
        err => {
          this.notificationService.warn(environment.SaveNotSuccess);          
        }
      );
    }
    else{
      this.hR_EmployeeService.add(form.value).subscribe(
        res => {
          this.notificationService.success(environment.SaveSuccess);          
        },
        err => {
          this.notificationService.warn(environment.SaveNotSuccess);          
        }
      );
    }    
  }

  onBackClicked() {
    this._location.back();
  }
}
