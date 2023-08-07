import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { SEOBlogTemplate } from 'src/app/shared/SEOBlogTemplate.model';
import { SEOBlogTemplateService } from 'src/app/shared/SEOBlogTemplate.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { SEOBlogTemplateDetailComponent } from './seoblog-template-detail/seoblog-template-detail.component';

@Component({
  selector: 'app-seoblog-template',
  templateUrl: './seoblog-template.component.html',
  styleUrls: ['./seoblog-template.component.css']
})
export class SEOBlogTemplateComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString; 
  URLSub: string = "SEOBlogTemplateInfo";
  constructor(
    public sEOBlogTemplateService: SEOBlogTemplateService,
    public notificationService: NotificationService,    
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.sEOBlogTemplateService.getAllToList().then(res => {
      this.sEOBlogTemplateService.list = res as SEOBlogTemplate[];      
    });
  }
  onSearch() {    
    this.getToList();
  }
  onAdd(ID: any) {    
    this.sEOBlogTemplateService.getByID(ID).then(res => {
      this.sEOBlogTemplateService.formData = res as SEOBlogTemplate;
    });
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;    
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(SEOBlogTemplateDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.getToList();      
    });
  }
}