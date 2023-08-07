import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Country } from 'src/app/shared/Country.model';
import { CountryService } from 'src/app/shared/Country.service';
import { Region } from 'src/app/shared/Region.model';
import { RegionService } from 'src/app/shared/Region.service';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-region',
  templateUrl: './region.component.html',
  styleUrls: ['./region.component.css']
})
export class RegionComponent implements OnInit {

  isShowLoading: boolean = false;
  countryID: string = environment.USID; 
  searchString: string = environment.InitializationString; 
  constructor(
    public countryService: CountryService,
    public regionService: RegionService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getCountryToList();    
  }
  getToList() {    
    this.isShowLoading = true;
    this.regionService.getByCountryIDOrSearchStringToList(this.countryID, this.searchString).then(res => {
      this.regionService.list = res as Region[];      
      this.isShowLoading = false;       
    });
  }
  getCountryToList() {    
    this.isShowLoading = true;
    this.countryService.GetAllToList().then(res => {
      this.countryService.list = res as Country[];    
      this.onSearch();          
      this.isShowLoading = false;       
    });
  }
  onSearch() {    
    this.getToList();
  }
}