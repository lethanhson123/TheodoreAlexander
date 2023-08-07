import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Banner } from 'src/app/shared/Banner.model';
import { BannerService } from 'src/app/shared/Banner.service';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-banner',
  templateUrl: './banner.component.html',
  styleUrls: ['./banner.component.css']
})
export class BannerComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString; 
  URLSub: string = "BannerInfo";
  constructor(
    public bannerService: BannerService,
    public notificationService: NotificationService,    
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {   
    this.isShowLoading = true; 
    this.bannerService.getAllToList().then(res => {
      this.bannerService.list = res as Banner[];  
      this.isShowLoading = false;    
    });
  } 
}