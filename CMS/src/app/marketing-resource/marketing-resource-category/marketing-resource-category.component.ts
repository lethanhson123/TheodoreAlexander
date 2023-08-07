import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MarketingResourceCategory } from 'src/app/shared/MarketingResourceCategory.model';
import { MarketingResourceCategoryService } from 'src/app/shared/MarketingResourceCategory.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { MarketingResourceCategoryDetailComponent } from './marketing-resource-category-detail/marketing-resource-category-detail.component';

@Component({
  selector: 'app-marketing-resource-category',
  templateUrl: './marketing-resource-category.component.html',
  styleUrls: ['./marketing-resource-category.component.css']
})
export class MarketingResourceCategoryComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString; 

  constructor(
    public marketingResourceCategoryService: MarketingResourceCategoryService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {   
    this.isShowLoading = true; 
    this.marketingResourceCategoryService.getAllToList().then(res => {
      this.marketingResourceCategoryService.list = res as MarketingResourceCategory[];  
      this.isShowLoading = false;    
    });
  }
  onSearch() {    
    this.getToList();
  }
  onAdd(ID: any) {    
    this.marketingResourceCategoryService.getByID(ID).then(res => {
      this.marketingResourceCategoryService.formData = res as MarketingResourceCategory;      
    });
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;    
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(MarketingResourceCategoryDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.getToList();      
    });
  }
}