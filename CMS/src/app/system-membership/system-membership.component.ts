import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { System_Membership } from 'src/app/shared/System_Membership.model';
import { System_MembershipService } from 'src/app/shared/System_Membership.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { MembershipDetailComponent } from './membership-detail/membership-detail.component';

@Component({
  selector: 'app-system-membership',
  templateUrl: './system-membership.component.html',
  styleUrls: ['./system-membership.component.css']
})
export class SystemMembershipComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString; 

  constructor(
    public system_MembershipService: System_MembershipService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.system_MembershipService.getBySearchStringToList(this.searchString).then(res => {
      this.system_MembershipService.list = res as System_Membership[];      
    });
  }
  onSearch() {    
    this.getToList();
  }
  onAdd(ID: any) {    
    this.system_MembershipService.getByID(ID).then(res => {
      this.system_MembershipService.formData = res as System_Membership;
    });
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;    
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(MembershipDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.getToList();      
    });
  }
}
