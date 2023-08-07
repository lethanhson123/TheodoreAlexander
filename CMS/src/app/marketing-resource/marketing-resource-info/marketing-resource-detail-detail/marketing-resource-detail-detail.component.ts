import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { MarketingResourceDetailService } from 'src/app/shared/MarketingResourceDetail.service';

@Component({
  selector: 'app-marketing-resource-detail-detail',
  templateUrl: './marketing-resource-detail-detail.component.html',
  styleUrls: ['./marketing-resource-detail-detail.component.css']
})
export class MarketingResourceDetailDetailComponent implements OnInit {

  ID: string = environment.InitializationString;  
  constructor(
    public marketingResourceDetailService: MarketingResourceDetailService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<MarketingResourceDetailDetailComponent>,
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
    this.marketingResourceDetailService.add(form.value).subscribe(
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