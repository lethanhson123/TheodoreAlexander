import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { RoomAndUsage } from 'src/app/shared/RoomAndUsage.model';
import { RoomAndUsageService } from 'src/app/shared/RoomAndUsage.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { RoomAndUsageDetailComponent } from './room-and-usage-detail/room-and-usage-detail.component';

@Component({
  selector: 'app-room-and-usage',
  templateUrl: './room-and-usage.component.html',
  styleUrls: ['./room-and-usage.component.css']
})
export class RoomAndUsageComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString; 

  constructor(
    public roomAndUsageService: RoomAndUsageService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.roomAndUsageService.getBySearchStringToList(this.searchString).then(res => {
      this.roomAndUsageService.list = res as RoomAndUsage[];            
    });
  }
  onSearch() {    
    this.getToList();
  }
  onAdd(ID: any) {    
    this.roomAndUsageService.getByID(ID).then(res => {
      this.roomAndUsageService.formData = res as RoomAndUsage;      
    });
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;    
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(RoomAndUsageDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.getToList();      
    });
  }
}