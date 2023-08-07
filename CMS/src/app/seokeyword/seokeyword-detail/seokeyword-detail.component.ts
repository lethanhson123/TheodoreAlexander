import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { SEOKeywordService } from 'src/app/shared/SEOKeyword.service';

@Component({
  selector: 'app-seokeyword-detail',
  templateUrl: './seokeyword-detail.component.html',
  styleUrls: ['./seokeyword-detail.component.css']
})
export class SEOKeywordDetailComponent implements OnInit {

  ID: string = environment.InitializationString;
  fileToUpload: any;
  fileToUploadImageName: any;
  constructor(
    public sEOKeywordService: SEOKeywordService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<SEOKeywordDetailComponent>,
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
    this.sEOKeywordService.add(form.value).subscribe(
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