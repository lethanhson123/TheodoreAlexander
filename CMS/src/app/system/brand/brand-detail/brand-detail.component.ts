import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { BrandService } from 'src/app/shared/Brand.service';

@Component({
  selector: 'app-brand-detail',
  templateUrl: './brand-detail.component.html',
  styleUrls: ['./brand-detail.component.css']
})
export class BrandDetailComponent implements OnInit {

  ID: string = environment.InitializationString;
  fileToUpload: any;
  fileToUploadImageName: any;
  constructor(
    public brandService: BrandService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<BrandDetailComponent>,
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
    this.brandService.addAndUploadImage(form.value, this.fileToUpload, this.fileToUpload).subscribe(
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
  changeImageName(e: Event) {  
    if (e) {
      this.fileToUploadImageName = (e.target as HTMLInputElement).files?.[0];
      if (this.fileToUploadImageName !== null) {
        var reader = new FileReader();
        reader.onload = (event: any) => {          
        };
        reader.readAsDataURL(this.fileToUploadImageName);
      }
    }
  }
}
