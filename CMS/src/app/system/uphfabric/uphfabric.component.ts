import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { UPHFabric } from 'src/app/shared/UPHFabric.model';
import { UPHFabricService } from 'src/app/shared/UPHFabric.service';
import { DownloadService } from 'src/app/shared/download.service';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-uphfabric',
  templateUrl: './uphfabric.component.html',
  styleUrls: ['./uphfabric.component.css']
})
export class UPHFabricComponent implements OnInit {

  isShowLoading: boolean = false;
  isFabric: boolean = false;
  isLeather: boolean = false;
  isTrims: boolean = false;
  searchString: string = environment.InitializationString; 

  constructor(
    public uPHFabricService: UPHFabricService,
    public notificationService: NotificationService,
    public downloadService: DownloadService,
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.isShowLoading = true;
    this.uPHFabricService.getByIsFabricAndIsLeatherAndIsTrimsAndSearchStringToList(this.isFabric, this.isLeather, this.isTrims, this.searchString).then(res => {
      this.uPHFabricService.list = res as UPHFabric[];      
      this.isShowLoading = false;       
    });
  }
  onSearch() {    
    this.getToList();
  }  
  onDownloadExcelFile() {
    this.isShowLoading = true;
    this.downloadService.getUPHFabricByIsFabricAndIsLeatherAndIsTrimsAndSearchStringExcel(this.isFabric, this.isLeather, this.isTrims, this.searchString).then(res => {        
        window.location.href = res.toString();       
        this.isShowLoading = false;
      }
    );
  }
}