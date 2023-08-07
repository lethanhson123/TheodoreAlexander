import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { SEOBlogTemplateService } from 'src/app/shared/SEOBlogTemplate.service';

@Component({
  selector: 'app-seoblog-template-detail',
  templateUrl: './seoblog-template-detail.component.html',
  styleUrls: ['./seoblog-template-detail.component.css']
})
export class SEOBlogTemplateDetailComponent implements OnInit {

  ID: string = environment.InitializationString;
  fileToUpload: any;
  fileToUploadImageName: any;
  constructor(
    public sEOBlogTemplateService: SEOBlogTemplateService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<SEOBlogTemplateDetailComponent>,
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
    this.sEOBlogTemplateService.saveAndUploadFiles(form.value, this.fileToUpload).subscribe(
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
  changeImage(e: Event) {
    if (e) {
      this.fileToUpload = (e.target as HTMLInputElement).files?.[0];
      if (this.fileToUpload !== null) {
        var reader = new FileReader();
        reader.onload = (event: any) => {
        };
        reader.readAsDataURL(this.fileToUpload);
      }
    }
  }
}