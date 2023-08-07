import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { DownloadService } from '../shared/download.service';
import { UserService } from '../shared/User.service';
import { UserDataTransfer } from '../shared/UserDataTransfer.model';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;  
  constructor(
    public userService: UserService,    
    public downloadService: DownloadService,
  ) { }

  ngOnInit(): void {    
    this.getUserDataTransferByRowNumberToList();
  }
  getUserDataTransferByRowNumberToList() {
    this.isShowLoading = true;
    this.userService.getDataTransferByRowNumberToList(50).then(res => {
      this.userService.listUserDataTransfer = res as UserDataTransfer[];
      this.isShowLoading = false;
    });
  }  
  onDownloadExcelFile() {
    this.isShowLoading = true;  
    this.downloadService.getUserDataTransferToExcel().then(
      res => {
        window.open(res.toString(), "_blank");
        this.isShowLoading = false;
      }
    );
  }
}
