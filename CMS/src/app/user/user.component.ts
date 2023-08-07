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
    this.userService.getDataTransferByRowNumberToList(10).then(res => {
      this.userService.listUserDataTransfer = res as UserDataTransfer[];
      this.isShowLoading = false;
      console.log(this.userService.listUserDataTransfer);
    });
  }  
  onDownloadExcelFile() {
    this.isShowLoading = true;  
    this.downloadService.getUserDataTransferToExcel().then(
      res => {
        window.location.href = res.toString();      
        this.isShowLoading = false;
      }
    );
  }
}
