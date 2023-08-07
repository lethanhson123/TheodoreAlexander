import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Designer } from 'src/app/shared/Designer.model';
import { DesignerService } from 'src/app/shared/Designer.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { DesignerDetailComponent } from './designer-detail/designer-detail.component';

@Component({
  selector: 'app-designer',
  templateUrl: './designer.component.html',
  styleUrls: ['./designer.component.css']
})
export class DesignerComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString; 

  constructor(
    public designerService: DesignerService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.designerService.getBySearchStringToList(this.searchString).then(res => {
      this.designerService.list = res as Designer[];   
      console.log(this.designerService.list);   
    });
  }
  onSearch() {    
    this.getToList();
  }
  onAdd(ID: any) {    
    this.designerService.getByID(ID).then(res => {
      this.designerService.formData = res as Designer;
    });
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;    
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(DesignerDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.getToList();      
    });
  }
}