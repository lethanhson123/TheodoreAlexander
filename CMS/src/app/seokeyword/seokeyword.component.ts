import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { SEOKeyword } from 'src/app/shared/SEOKeyword.model';
import { SEOKeywordService } from 'src/app/shared/SEOKeyword.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { SEOKeywordDetailComponent } from './seokeyword-detail/seokeyword-detail.component';

@Component({
  selector: 'app-seokeyword',
  templateUrl: './seokeyword.component.html',
  styleUrls: ['./seokeyword.component.css']
})
export class SEOKeywordComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString; 

  constructor(
    public sEOKeywordService: SEOKeywordService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.sEOKeywordService.getAllToList().then(res => {
      this.sEOKeywordService.list = res as SEOKeyword[];      
    });
  }
  onSearch() {    
    this.getToList();
  }
  onAdd(ID: any) {    
    this.sEOKeywordService.getByID(ID).then(res => {
      this.sEOKeywordService.formData = res as SEOKeyword;
    });
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;    
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(SEOKeywordDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.getToList();      
    });
  }
}
