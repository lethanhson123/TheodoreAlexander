import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { UPHColour } from 'src/app/shared/UPHColour.model';
import { UPHColourService } from 'src/app/shared/UPHColour.service';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-uphcolour',
  templateUrl: './uphcolour.component.html',
  styleUrls: ['./uphcolour.component.css']
})
export class UPHColourComponent implements OnInit {

  isShowLoading: boolean = false;  
  searchString: string = environment.InitializationString; 
  constructor(
    public uPHColourService: UPHColourService,
    public notificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.isShowLoading = true;
    this.uPHColourService.getAllToList().then(res => {
      this.uPHColourService.list = res as UPHColour[];     
      this.isShowLoading = false;       
    });
  }
  onUPHColourSave(item: UPHColour){        
    this.uPHColourService.update(item).subscribe(
      res => {       
        this.notificationService.warn(environment.SaveSuccess);        
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);        
      }
    );
  }
}
