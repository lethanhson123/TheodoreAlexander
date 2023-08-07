import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { BannerDetailService } from 'src/app/shared/BannerDetail.service';

@Component({
  selector: 'app-banner-detail-detail',
  templateUrl: './banner-detail-detail.component.html',
  styleUrls: ['./banner-detail-detail.component.css']
})
export class BannerDetailDetailComponent implements OnInit {

  ID: string = environment.InitializationString;
  fileToUploadImageDesktop: any;
  fileToUploadImageMobile: any;
  fileToUploadImageName: any;
  fileToUpload: any;
  constructor(
    public bannerDetailService: BannerDetailService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<BannerDetailDetailComponent>,
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
    this.bannerDetailService.saveAndUploadFiles(form.value, this.fileToUploadImageDesktop, this.fileToUploadImageMobile, this.fileToUploadImageName).subscribe(
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
  changeImageDesktop(e: Event) {
    if (e) {
      this.fileToUploadImageDesktop = (e.target as HTMLInputElement).files?.[0];
      if (this.fileToUploadImageDesktop !== null) {
        var reader = new FileReader();
        reader.onload = (event: any) => {
        };
        reader.readAsDataURL(this.fileToUploadImageDesktop);
      }
    }
  }
  changeImageMobile(e: Event) {
    if (e) {
      this.fileToUploadImageMobile = (e.target as HTMLInputElement).files?.[0];
      if (this.fileToUploadImageMobile !== null) {
        var reader = new FileReader();
        reader.onload = (event: any) => {
        };
        reader.readAsDataURL(this.fileToUploadImageMobile);
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
