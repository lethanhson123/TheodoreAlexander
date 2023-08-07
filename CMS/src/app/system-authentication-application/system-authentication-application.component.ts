import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { System_AuthenticationApplicationDataTransfer } from 'src/app/shared/System_AuthenticationApplicationDataTransfer.model';
import { System_AuthenticationApplication } from 'src/app/shared/System_AuthenticationApplication.model';
import { System_AuthenticationApplicationService } from 'src/app/shared/System_AuthenticationApplication.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { AuthenticationApplicationDetailComponent } from './authentication-application-detail/authentication-application-detail.component';

@Component({
  selector: 'app-system-authentication-application',
  templateUrl: './system-authentication-application.component.html',
  styleUrls: ['./system-authentication-application.component.css']
})
export class SystemAuthenticationApplicationComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;

  constructor(
    public system_AuthenticationApplicationService: System_AuthenticationApplicationService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {
    this.system_AuthenticationApplicationService.getDataTransferBySearchStringToList(this.searchString).then(res => {
      this.system_AuthenticationApplicationService.listDataTransfer = res as System_AuthenticationApplicationDataTransfer[];
    });
  }
  onSearch() {
    this.getToList();
  }
  onAdd(ID: any) {
    this.system_AuthenticationApplicationService.getByID(ID).then(res => {
      this.system_AuthenticationApplicationService.formData = res as System_AuthenticationApplication;
    });
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(AuthenticationApplicationDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.getToList();
    });
  }
}
