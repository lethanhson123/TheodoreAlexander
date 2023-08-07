import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { HR_Covid } from 'src/app/shared/HR_Covid.model';
import { HR_CovidDataTransfer } from 'src/app/shared/HR_CovidDataTransfer.model';
import { HR_CovidService } from 'src/app/shared/HR_Covid.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { HRCovidDetailComponent } from 'src/app/hr-covid/hr-covid-detail/hr-covid-detail.component';
@Component({
  selector: 'app-hr-covid',
  templateUrl: './hr-covid.component.html',
  styleUrls: ['./hr-covid.component.css']
})
export class HRCovidComponent implements OnInit {

  isShowLoading: boolean = false;
  displayColumns: string[] = ['EmployeeID'];
  searchString: string = environment.InitializationString;
  codeManage: string = environment.InitializationString;
  constructor(
    public hR_CovidService: HR_CovidService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
    this.getCodeManageToList();
  }
  getToList() {    
    this.hR_CovidService.getDataTransferBySearchStringAndCodeManageToList(this.searchString, this.codeManage).then(res => {
      this.hR_CovidService.listDataTransfer = res as HR_CovidDataTransfer[];      
    });
  }
  getCodeManageToList() {    
    this.hR_CovidService.getByWithCodeManageToList().then(res => {
      this.hR_CovidService.list = res as HR_Covid[];      
    });
  }
  onSearch() {    
    this.getToList();
  }
  onChangeCodeManage() {    
    this.getToList();
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
      this.getToList();
      this.getCodeManageToList();
    });
  }
}
