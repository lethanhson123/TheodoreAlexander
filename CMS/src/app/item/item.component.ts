import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Item } from 'src/app/shared/Item.model';
import { ItemDataTransfer } from 'src/app/shared/ItemDataTransfer.model';
import { ItemService } from 'src/app/shared/Item.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { ItemDetailComponent } from './item-detail/item-detail.component';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {

  website: string = environment.Website;
  productDetail: string = environment.ProductDetail;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString; 

  constructor(
    public itemService: ItemService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { 
    this.itemService.listItemDataTransfer=[];
  }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.isShowLoading = true;    
    this.itemService.getDataTransferBySearchStringToList(this.searchString).then(res => {
      this.itemService.listItemDataTransfer = res as ItemDataTransfer[];   
      this.isShowLoading = false;      
    });
  }
  onSearch() {    
    this.getToList();
  }
  onAdd(ID: any) {    
    this.itemService.getByID(ID).then(res => {
      this.itemService.formData = res as Item;
    });
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;    
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(ItemDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.getToList();      
    });
  }
  onUpdateItemsURLCode() {    
    this.isShowLoading = true;
    this.itemService.updateItemsURLCode().then(res => {      
      this.isShowLoading = false;   
      this.getToList();
    });
  }
}