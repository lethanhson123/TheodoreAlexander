import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Collection } from 'src/app/shared/Collection.model';
import { CollectionService } from 'src/app/shared/Collection.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { CollectionDetailComponent } from './collection-detail/collection-detail.component';
import { CollectionDataTransfer } from 'src/app/shared/CollectionDataTransfer.model';

@Component({
  selector: 'app-collection',
  templateUrl: './collection.component.html',
  styleUrls: ['./collection.component.css']
})
export class CollectionComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString; 

  constructor(
    public collectionService: CollectionService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.collectionService.getDataTransferBySearchStringToList(this.searchString).then(res => {
      this.collectionService.listDataTransfer = res as CollectionDataTransfer[];      
    });
  }
  onSearch() {    
    this.getToList();
  }
  onAdd(ID: any) {    
    console.log(ID);
    this.collectionService.getByID(ID).then(res => {
      this.collectionService.formData = res as Collection;
      console.log(this.collectionService.formData);
    });
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;    
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(CollectionDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.getToList();      
    });
  }
}