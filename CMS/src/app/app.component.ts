import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router, NavigationEnd } from '@angular/router';
import { System_AuthenticationToken } from 'src/app/shared/System_AuthenticationToken.model';
import { System_AuthenticationTokenService } from 'src/app/shared/System_AuthenticationToken.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title: string = 'CMS';
  domainURL: string = environment.DomainURL;
  queryString: string = environment.InitializationString;
  authenticationToken: string = environment.InitializationString;
  membershipID: number = environment.InitializationNumber;
  constructor(
    public router: Router,
    public system_AuthenticationTokenService: System_AuthenticationTokenService,
  ) {
    this.getByQueryString();
  }
  getByQueryString() {
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        this.queryString = event.url;        
        if (this.queryString.indexOf(environment.AuthenticationToken) > -1) {          
          localStorage.setItem(environment.AuthenticationToken, this.queryString.split('=')[this.queryString.split('=').length - 1]);
        }
        //this.checkAuthenticationToken();
      }
    });
  }
  checkAuthenticationToken() {
    let destinationURL = environment.LoginURL + "?url=" + environment.DomainDestination;
    let authenticationToken = localStorage.getItem(environment.AuthenticationToken);
    if (authenticationToken == null) {
      window.location.href = destinationURL;
    }
    else {      
      this.system_AuthenticationTokenService.getByAuthenticationToken(authenticationToken).then(res => {
        let system_AuthenticationToken = res as System_AuthenticationToken;
        if (system_AuthenticationToken != null) {
          this.membershipID = system_AuthenticationToken.MembershipID as number;
          if (this.membershipID > 0) {
            localStorage.setItem(environment.MembershipID, this.membershipID.toString());                        
          }
          else {
            window.location.href = destinationURL;
          }
        }
      });
    }
  }
  ngOnInit() {
  }
}
