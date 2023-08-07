import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { System_Application } from 'src/app/shared/System_Application.model';
import { System_ApplicationService } from 'src/app/shared/System_Application.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { ApplicationDetailComponent } from './application-detail/application-detail.component';

@Component({
  selector: 'app-system-application',
  templateUrl: './system-application.component.html',
  styleUrls: ['./system-application.component.css']
})
export class SystemApplicationComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString; 

  constructor(
    public system_ApplicationService: System_ApplicationService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.system_ApplicationService.getBySearchStringToList(this.searchString).then(res => {
      this.system_ApplicationService.list = res as System_Application[];      
    });
  }
  onSearch() {    
    this.getToList();
  }
  onAdd(ID: any) {    
    this.system_ApplicationService.getByID(ID).then(res => {
      this.system_ApplicationService.formData = res as System_Application;
    });
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;    
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(ApplicationDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.getToList();      
    });
  }
}
