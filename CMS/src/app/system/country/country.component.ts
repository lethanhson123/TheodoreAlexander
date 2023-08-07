import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Country } from 'src/app/shared/Country.model';
import { CountryService } from 'src/app/shared/Country.service';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css']
})
export class CountryComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString; 

  constructor(
    public countryService: CountryService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.isShowLoading = true;
    this.countryService.getBySearchStringToList(this.searchString).then(res => {
      this.countryService.list = res as Country[];      
      this.isShowLoading = false;       
    });
  }
  onSearch() {    
    this.getToList();
  }
}
