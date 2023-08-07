import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { MarketingResourceCategoryService } from 'src/app/shared/MarketingResourceCategory.service';


@Component({
  selector: 'app-marketing-resource-category-detail',
  templateUrl: './marketing-resource-category-detail.component.html',
  styleUrls: ['./marketing-resource-category-detail.component.css']
})
export class MarketingResourceCategoryDetailComponent implements OnInit {

  ID: string = environment.InitializationString;  
  constructor(
    public marketingResourceCategoryService: MarketingResourceCategoryService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<MarketingResourceCategoryDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { 
    this.ID = data["ID"] as string;
  }

  ngOnInit(): void {
  }
  onClose() {    
    this.dialogRef.close();
  }
  onSubmit(form: NgForm) {
    this.marketingResourceCategoryService.add(form.value).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.onClose();
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.onClose();
      }
    );
  }  
}