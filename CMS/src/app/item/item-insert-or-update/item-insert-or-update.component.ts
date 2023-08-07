import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UploadService } from 'src/app/shared/upload.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { Item } from 'src/app/shared/Item.model';
import { ItemService } from 'src/app/shared/Item.service';

@Component({
  selector: 'app-item-insert-or-update',
  templateUrl: './item-insert-or-update.component.html',
  styleUrls: ['./item-insert-or-update.component.css']
})
export class ItemInsertOrUpdateComponent implements OnInit {

  website: string = environment.Website;
  productDetail: string = environment.ProductDetail;
  isShowLoading: boolean = false;  
  itemExcelTemplateURL: string = environment.APIURL + environment.Download + "/" + environment.ItemExcelFileName;
  @ViewChild('uploadItem') uploadItem!: ElementRef;
  constructor(
    public itemService: ItemService,
    public uploadService: UploadService,
    public notificationService: NotificationService,
  ) { }

  ngOnInit(): void {
  } 
  onSubmit() {
    let fileToUpload: File;
    fileToUpload = this.uploadItem.nativeElement.files[0];    
    this.isShowLoading = true;
    this.uploadService.postItemByExcelFile(fileToUpload).subscribe(
      data => {         
        this.itemService.formData.SKU=data as string;        
        this.itemService.postBySKUListToList(this.itemService.formData).subscribe(
          res => {           
            this.itemService.list = res as Item[];    
            this.isShowLoading = false;
            this.notificationService.success(environment.UploadSuccess);   
          },
          err => {
            this.notificationService.warn(environment.UploadNotSuccess);
          }
        );
      },
      err => {        
        this.isShowLoading = false;
        this.notificationService.warn(environment.UploadNotSuccess);
      }
    );
  }
}