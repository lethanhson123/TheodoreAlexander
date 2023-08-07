import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Shape } from 'src/app/shared/Shape.model';
import { ShapeService } from 'src/app/shared/Shape.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { ShapeDetailComponent } from './shape-detail/shape-detail.component';

@Component({
  selector: 'app-shape',
  templateUrl: './shape.component.html',
  styleUrls: ['./shape.component.css']
})
export class ShapeComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString; 

  constructor(
    public shapeService: ShapeService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.shapeService.getBySearchStringToList(this.searchString).then(res => {
      this.shapeService.list = res as Shape[];      
    });
  }
  onSearch() {    
    this.getToList();
  }
  onAdd(ID: any) {    
    this.shapeService.getByID(ID).then(res => {
      this.shapeService.formData = res as Shape;
    });
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;    
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(ShapeDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.getToList();      
    });
  }
}
