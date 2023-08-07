import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { HR_Covid } from 'src/app/shared/HR_Covid.model';
import { HR_CovidDataTransfer } from 'src/app/shared/HR_CovidDataTransfer.model';
import { HR_CovidService } from 'src/app/shared/HR_Covid.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { HRCovidDetailComponent } from 'src/app/hr-covid/hr-covid-detail/hr-covid-detail.component';

@Component({
  selector: 'app-hr-covid-f1',
  templateUrl: './hr-covid-f1.component.html',
  styleUrls: ['./hr-covid-f1.component.css']
})
export class HRCovidF1Component implements OnInit {

  isShowLoading: boolean = false;  
  displayColumns: string[] = ['EmployeeID'];
  searchString: string=environment.InitializationString;  
  constructor(
    public hR_CovidService: HR_CovidService,
    public notificationService: NotificationService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {    
    this.hR_CovidService.getByF1ToList().then(res => {
      this.hR_CovidService.listDataTransfer = res as HR_CovidDataTransfer[];           
    });
  }
  onSearch() {    
  }
  onAdd(ID: any) {   
    this.hR_CovidService.getByID(ID).then(res => {
      this.hR_CovidService.formData = res as HR_Covid;      
    });
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = environment.DialogConfigWidth;
    dialogConfig.height = "200%";
    dialogConfig.data = { ID: ID };
    const dialog = this.dialog.open(HRCovidDetailComponent, dialogConfig);
    dialog.afterClosed().subscribe(() => {
      this.getToList();
    }); 
  }

}
