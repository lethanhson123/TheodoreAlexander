import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HR_EmployeeDataTransfer } from 'src/app/shared/HR_EmployeeDataTransfer.model';
import { HR_EmployeeService } from 'src/app/shared/HR_Employee.service';
@Component({
  selector: 'app-hr-employee',
  templateUrl: './hr-employee.component.html',
  styleUrls: ['./hr-employee.component.css']
})
export class HREmployeeComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  count: number = environment.InitializationNumber;
  constructor(
    public hR_EmployeeService: HR_EmployeeService,
  ) { }

  ngOnInit(): void {
    this.getToList();
  }

  getToList() {
    this.hR_EmployeeService.asyncGetDataTransferBySearchStringToList(this.searchString).then(res => {
      this.hR_EmployeeService.listHR_EmployeeDataTransfer = res as HR_EmployeeDataTransfer[];
    });
  }
  onSearch(event: any) {
    if (event.keyCode == 13) {
      this.getToList();
    }
  }
}
