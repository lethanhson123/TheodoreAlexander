import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { LifeStyle } from 'src/app/shared/LifeStyle.model';
import { LifeStyleService } from 'src/app/shared/LifeStyle.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { LifeStyleDetailComponent } from './life-style-detail/life-style-detail.component';

@Component({
  selector: 'app-life-style',
  templateUrl: './life-style.component.html',
  styleUrls: ['./life-style.component.css']
})
export class LifeStyleComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public lifeStyleService: LifeStyleService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.lifeStyleService.getBySearchStringToList(this.searchString).then(res => {
      this.lifeStyleService.list = res as LifeStyle[];      
    });
  }
  onSearch() {    
    this.getToList();
  }
  onAdd(ID: any) {    
    this.lifeStyleService.getByID(ID).then(res => {
      this.lifeStyleService.formData = res as LifeStyle;
    });
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;    
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(LifeStyleDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.getToList();      
    });
  }
}
