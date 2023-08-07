import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { DownloadService } from '../shared/download.service';
import { Store } from '../shared/Store.model';
import { StoreService } from '../shared/Store.service';
import { UserService } from '../shared/User.service';
import { UserDataTransfer } from '../shared/UserDataTransfer.model';

@Component({
  selector: 'app-user-by-store',
  templateUrl: './user-by-store.component.html',
  styleUrls: ['./user-by-store.component.css']
})
export class UserByStoreComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  storeIDSearchString: string = "780e4503-e38f-4c29-a0ff-7f20e44a9961";
  constructor(
    public userService: UserService,
    public storeService: StoreService,
    public downloadService: DownloadService,
  ) { }

  ngOnInit(): void {
    this.getStoreBySearchStringToList(this.searchString);
    this.getUserDataTransferByStoreIDToList();
  }
  getUserDataTransferByStoreIDToList() {
    this.isShowLoading = true;
    this.userService.getDataTransferByStoreIDToList(this.storeIDSearchString).then(res => {
      this.userService.listUserDataTransfer = res as UserDataTransfer[];
      this.isShowLoading = false;
    });
  }
  getStoreBySearchStringToList(searchString: string) {
    this.isShowLoading = true;
    this.storeService.getBySearchStringToList(searchString).then(res => {
      this.storeService.list = res as Store[];
      this.isShowLoading = false;
    });
  }
  onChangeStore() {
    this.getUserDataTransferByStoreIDToList();
  }
  onFilterStore(event: Event) {
    let searchString: string = (event.target as HTMLInputElement).value;
    this.getStoreBySearchStringToList(searchString);
  }
  onDownloadExcelFile() {
    this.isShowLoading = true;  
    this.downloadService.getUserDataTransferByStoreIDToExcel(this.storeIDSearchString).then(
      res => {
        window.location.href = res.toString();      
        this.isShowLoading = false;
      }
    );
  }

}
