import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Type } from 'src/app/shared/Type.model';
import { TypeDataTransfer } from 'src/app/shared/TypeDataTransfer.model';
import { TypeService } from 'src/app/shared/Type.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { TypeDetailComponent } from './type-detail/type-detail.component';

@Component({
  selector: 'app-type',
  templateUrl: './type.component.html',
  styleUrls: ['./type.component.css']
})
export class TypeComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString; 

  constructor(
    public typeService: TypeService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.typeService.getDataTransferBySearchStringToList(this.searchString).then(res => {
      this.typeService.listDataTransfer = res as TypeDataTransfer[];      
    });
  }
  onSearch() {    
    this.getToList();
  }
  onAdd(ID: any) {    
    this.typeService.getByID(ID).then(res => {
      this.typeService.formData = res as Type;
    });
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;    
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(TypeDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.getToList();      
    });
  }
}
