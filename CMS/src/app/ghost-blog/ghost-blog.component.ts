import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { GhostBlog } from 'src/app/shared/GhostBlog.model';
import { GhostBlogService } from 'src/app/shared/GhostBlog.service';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-ghost-blog',
  templateUrl: './ghost-blog.component.html',
  styleUrls: ['./ghost-blog.component.css']
})
export class GhostBlogComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString; 
  website: string = environment.Website;
  constructor(
    public ghostBlogService: GhostBlogService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.ghostBlogService.getBySearchStringToList(this.searchString).then(res => {
      this.ghostBlogService.list = res as GhostBlog[];      
    });
  }
  onSearch() {    
    this.getToList();
  } 
  onInitializationGhostToGhostBlog() {
    this.isShowLoading = true;  
    this.ghostBlogService.initializationGhostToGhostBlog().then(
      res => {
        this.notificationService.success(environment.SaveSuccess);  
        this.isShowLoading = false;           
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);        
      }
    );
  }
}