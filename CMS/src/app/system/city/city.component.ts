import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Country } from 'src/app/shared/Country.model';
import { CountryService } from 'src/app/shared/Country.service';
import { Region } from 'src/app/shared/Region.model';
import { RegionService } from 'src/app/shared/Region.service';
import { City } from 'src/app/shared/City.model';
import { CityService } from 'src/app/shared/City.service';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.css']
})
export class CityComponent implements OnInit {

  isShowLoading: boolean = false;
  countryID: string = environment.USID; 
  regionID: string = environment.InitializationString; 
  searchString: string = environment.InitializationString; 
  constructor(
    public countryService: CountryService,
    public regionService: RegionService,
    public cityService: CityService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getCountryToList();    
  }
  getRegionToList() {    
    this.isShowLoading = true;
    this.regionService.getByCountryIDToList(this.countryID).then(res => {
      this.regionService.list = res as Region[];      
      this.isShowLoading = false;       
    });
  }
  getCountryToList() {    
    this.isShowLoading = true;
    this.countryService.GetAllToList().then(res => {
      this.countryService.list = res as Country[];  
      this.getRegionToList();          
      this.isShowLoading = false;       
    });
  }
  getToList() {    
    this.isShowLoading = true;
    this.cityService.getByRegionIDOrSearchStringToList(this.regionID, this.searchString).then(res => {
      this.cityService.list = res as Region[];      
      this.isShowLoading = false;       
    });
  }
  onCountryChange() {
    this.getRegionToList();
  }
  onSearch() {    
    this.getToList();
  }
}