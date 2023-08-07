import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { System_AuthenticationApplicationService } from 'src/app/shared/System_AuthenticationApplication.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { System_Membership } from 'src/app/shared/System_Membership.model';
import { System_MembershipService } from 'src/app/shared/System_Membership.service';
import { System_Application } from 'src/app/shared/System_Application.model';
import { System_ApplicationService } from 'src/app/shared/System_Application.service';

@Component({
  selector: 'app-authentication-application-detail',
  templateUrl: './authentication-application-detail.component.html',
  styleUrls: ['./authentication-application-detail.component.css']
})
export class AuthenticationApplicationDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  searchString: string = environment.InitializationString;
  constructor(
    public system_AuthenticationApplicationService: System_AuthenticationApplicationService,
    public system_MembershipService: System_MembershipService,
    public system_ApplicationService: System_ApplicationService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<AuthenticationApplicationDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.ID = data["ID"] as number;
    this.getSystem_MembershipToList();
    this.getSystem_ApplicationToList();
  }

  ngOnInit(): void {
  }
  getSystem_MembershipToList() {
    this.system_MembershipService.getBySearchStringToList(this.searchString).then(res => {
      this.system_MembershipService.list = res as System_Membership[];      
    });
  }
  getSystem_ApplicationToList() {
    this.system_ApplicationService.getBySearchStringToList(this.searchString).then(res => {
      this.system_ApplicationService.list = res as System_Application[];      
    });
  }
  onClose() {
    this.dialogRef.close();
  }
  onSubmit(form: NgForm) {
    console.log(form.value);
    this.system_AuthenticationApplicationService.add(form.value).subscribe(
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