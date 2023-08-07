import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NgForm } from '@angular/forms';
import { NotificationService } from 'src/app/shared/notification.service';
import { System_Membership } from 'src/app/shared/System_Membership.model';
import { System_MembershipService } from 'src/app/shared/System_Membership.service';
import { DownloadService } from 'src/app/shared/download.service';

@Component({
  selector: 'app-membership-infomation',
  templateUrl: './membership-infomation.component.html',
  styleUrls: ['./membership-infomation.component.css']
})
export class MembershipInfomationComponent implements OnInit {

  isShowLoading: boolean = false;
  constructor(
    public system_MembershipService: System_MembershipService,
    public downloadService: DownloadService,
    public notificationService: NotificationService,
  ) { 
    this.getMembershipByID();
  }

  ngOnInit(): void {
  }
  getMembershipByID() {    
    this.system_MembershipService.getByID(this.downloadService.getLocalStorageMembershipID()).then(res => {
      this.system_MembershipService.formData = res as System_Membership;
    });
  }
  onSubmit(form: NgForm) {    
    this.system_MembershipService.update001(form.value).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
}
