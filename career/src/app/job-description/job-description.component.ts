import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-job-description',
  templateUrl: './job-description.component.html',
  styleUrls: ['./job-description.component.scss']
})
export class JobDescriptionComponent implements OnInit {

  queryString: string = environment.InitializationString;
  VN001: boolean = false;
  VN002: boolean = false;
  VN003: boolean = false;
  VN004: boolean = false;
  VN005: boolean = false;
  VN006: boolean = false;
  VN007: boolean = false;
  VN008: boolean = false;
  VN009: boolean = false;
  VN010: boolean = false;
  EN001: boolean = false;
  EN002: boolean = false;
  EN003: boolean = false;
  EN004: boolean = false;
  EN005: boolean = false;
  EN006: boolean = false;
  EN007: boolean = false;
  EN008: boolean = false;
  EN009: boolean = false;
  EN010: boolean = false;
  constructor(public router: Router,) {
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        this.queryString = event.url;
        if (this.queryString == "/description/VN001") {
          this.VN001 = true;
        }
        if (this.queryString == "/description/VN002") {
          this.VN002 = true;
        }
        if (this.queryString == "/description/VN003") {
          this.VN003 = true;
        }
        if (this.queryString == "/description/VN004") {
          this.VN004 = true;
        }
        if (this.queryString == "/description/VN005") {
          this.VN005 = true;
        }
        if (this.queryString == "/description/VN006") {
          this.VN006 = true;
        }
        if (this.queryString == "/description/VN007") {
          this.VN007 = true;
        }
        if (this.queryString == "/description/VN008") {
          this.VN008 = true;
        }
        if (this.queryString == "/description/VN009") {
          this.VN009 = true;
        }
        if (this.queryString == "/description/VN010") {
          this.VN010 = true;
        }
        if (this.queryString == "/description/EN001") {
          this.EN001 = true;
        }
        if (this.queryString == "/description/EN002") {
          this.EN002 = true;
        }
        if (this.queryString == "/description/EN003") {
          this.EN003 = true;
        }
        if (this.queryString == "/description/EN004") {
          this.EN004 = true;
        }
        if (this.queryString == "/description/EN005") {
          this.EN005 = true;
        }
        if (this.queryString == "/description/EN006") {
          this.EN006 = true;
        }
        if (this.queryString == "/description/EN007") {
          this.EN007 = true;
        }
        if (this.queryString == "/description/EN008") {
          this.EN008 = true;
        }
        if (this.queryString == "/description/EN009") {
          this.EN009 = true;
        }
        if (this.queryString == "/description/EN010") {
          this.EN010 = true;
        }
      }
    });
  }

  ngOnInit(): void {
  }

}
