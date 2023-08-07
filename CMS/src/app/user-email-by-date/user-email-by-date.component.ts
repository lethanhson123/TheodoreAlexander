import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { DownloadService } from '../shared/download.service';
import { UserService } from '../shared/User.service';
import { UserDataTransfer } from '../shared/UserDataTransfer.model';
import { UserEmailDataTransfer } from '../shared/UserEmailDataTransfer.model';
import { NotificationService } from 'src/app/shared/notification.service';
@Component({
  selector: 'app-user-email-by-date',
  templateUrl: './user-email-by-date.component.html',
  styleUrls: ['./user-email-by-date.component.css']
})
export class UserEmailByDateComponent implements OnInit {

  isShowLoading: boolean = false;
  dateBeginYear: number = new Date().getFullYear();
  dateBeginMonth: number = new Date().getMonth() + 1;
  dateBeginDay: number = 1;
  dateEndYear: number = new Date().getFullYear();
  dateEndMonth: number = new Date().getMonth() + 1;
  dateEndDay: number = 31;
  isSubcribed: boolean = true;
  isRegister: boolean = true;
  isQuotation: boolean = true;
  isQuoteUS: boolean = false;
  isUserUS: boolean = false;
  isSubscriberUS: boolean = false;

  constructor(
    public userService: UserService,
    public downloadService: DownloadService,
    public notificationService: NotificationService,
  ) { }

  ngOnInit(): void {
  }
  getUserEmailDataTransferByDateBeginAndDateEndToList() {
    this.isShowLoading = true;
    this.userService.getUserEmailDataTransferByDateBeginAndDateEndToList(this.dateBeginYear, this.dateBeginMonth, this.dateBeginDay, this.dateEndYear, this.dateEndMonth, this.dateEndDay, this.isSubcribed, this.isRegister, this.isQuotation).then(res => {
      this.userService.listUserDataTransfer = res as UserDataTransfer[];
      this.isShowLoading = false;
    });
  }
  onSearch() {
    this.getUserEmailDataTransferByDateBeginAndDateEndToList();
  }
  onDownloadExcelFile() {
    this.isShowLoading = true;
    this.downloadService.getUserEmailDataTransferByDateBeginAndDateEndToExcel(this.dateBeginYear, this.dateBeginMonth, this.dateBeginDay, this.dateEndYear, this.dateEndMonth, this.dateEndDay, this.isSubcribed, this.isRegister, this.isQuotation).then(
      res => {        
        window.location.href = res.toString();       
        this.isShowLoading = false;
      }
    );
  }
  onSyncEMMA() {
    this.isShowLoading = true;
    this.userService.syncEMMA(this.dateBeginYear, this.dateBeginMonth, this.dateBeginDay, this.dateEndYear, this.dateEndMonth, this.dateEndDay, this.isSubcribed, this.isRegister, this.isQuotation, this.isSubscriberUS, this.isUserUS, this.isQuoteUS).then(res => {      
      this.isShowLoading = false;
      this.notificationService.success(environment.SaveSuccess);
    });
  }
}