import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Style } from 'src/app/shared/Style.model';
import { StyleService } from 'src/app/shared/Style.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { StyleDetailComponent } from './style-detail/style-detail.component';

@Component({
  selector: 'app-style',
  templateUrl: './style.component.html',
  styleUrls: ['./style.component.css']
})
export class StyleComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public styleService: StyleService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.styleService.getBySearchStringToList(this.searchString).then(res => {
      this.styleService.list = res as Style[];      
    });
  }
  onSearch() {    
    this.getToList();
  }
  onAdd(ID: any) {    
    this.styleService.getByID(ID).then(res => {
      this.styleService.formData = res as Style;
    });
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;    
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(StyleDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.getToList();      
    });
  }
}