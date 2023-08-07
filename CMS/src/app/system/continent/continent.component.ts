import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Continent } from 'src/app/shared/Continent.model';
import { ContinentService } from 'src/app/shared/Continent.service';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-continent',
  templateUrl: './continent.component.html',
  styleUrls: ['./continent.component.css']
})
export class ContinentComponent implements OnInit {

  isShowLoading: boolean = false;  
  searchString: string = environment.InitializationString; 
  constructor(
    public continentService: ContinentService,
    public notificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.isShowLoading = true;
    this.continentService.getAllToList().then(res => {
      this.continentService.list = res as Continent[];     
      this.isShowLoading = false;       
    });
  }  
}