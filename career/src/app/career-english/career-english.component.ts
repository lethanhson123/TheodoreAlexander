import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-career-english',
  templateUrl: './career-english.component.html',
  styleUrls: ['./career-english.component.scss']
})
export class CareerEnglishComponent implements OnInit {

  isVisible01Popup: boolean;
  isVisible02Popup: boolean;
  constructor() {  
  }

  ngOnInit() {    
  }

  onCancel01Popup(){
    this.isVisible01Popup = false;
  }  
  onCancel02Popup(){
    this.isVisible02Popup = false;
  }  

}
