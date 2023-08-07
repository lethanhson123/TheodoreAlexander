import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-career',
  templateUrl: './career.component.html',
  styleUrls: ['./career.component.scss']
})
export class CareerComponent implements OnInit {

  isVisible01Popup: boolean;
  isVisible02Popup: boolean;
  constructor(    
  ) {}

  ngOnInit() {
  }  
  onCancel01Popup() {
    this.isVisible01Popup = false;
  }
  onCancel02Popup() {
    this.isVisible02Popup = false;
  }

}
