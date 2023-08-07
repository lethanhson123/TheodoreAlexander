import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { DesignerService } from 'src/app/shared/Designer.service';

@Component({
  selector: 'app-designer-detail',
  templateUrl: './designer-detail.component.html',
  styleUrls: ['./designer-detail.component.css']
})
export class DesignerDetailComponent implements OnInit {

  ID: string = environment.InitializationString;
  fileToUploadImageIcon: any;
  fileToUploadImageMain: any;
  fileToUploadImageBackground: any;
  constructor(
    public designerService: DesignerService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<DesignerDetailComponent>,
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
    this.designerService.addAndUploadImage(form.value, this.fileToUploadImageIcon, this.fileToUploadImageMain, this.fileToUploadImageBackground).subscribe(
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
  changeImageIcon(e: Event) {
    if (e) {
      this.fileToUploadImageIcon = (e.target as HTMLInputElement).files?.[0];
      if (this.fileToUploadImageIcon !== null) {
        var reader = new FileReader();
        reader.onload = (event: any) => {
        };
        reader.readAsDataURL(this.fileToUploadImageIcon);
      }
    }
  }
  changeImageMain(e: Event) {
    if (e) {
      this.fileToUploadImageMain = (e.target as HTMLInputElement).files?.[0];
      if (this.fileToUploadImageMain !== null) {
        var reader = new FileReader();
        reader.onload = (event: any) => {
        };
        reader.readAsDataURL(this.fileToUploadImageMain);
      }
    }
  }
  changeImageBackground(e: Event) {
    if (e) {
      this.fileToUploadImageBackground = (e.target as HTMLInputElement).files?.[0];
      if (this.fileToUploadImageBackground !== null) {
        var reader = new FileReader();
        reader.onload = (event: any) => {
        };
        reader.readAsDataURL(this.fileToUploadImageBackground);
      }
    }
  }
}
