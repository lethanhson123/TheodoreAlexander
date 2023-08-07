import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router, NavigationEnd } from '@angular/router';
import { System_Membership } from 'src/app/shared/System_Membership.model';
import { System_MembershipService } from 'src/app/shared/System_Membership.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Login';
  queryString: string = environment.InitializationString;
  email: string = environment.InitializationString;
  password: string = environment.InitializationString;
  urlDestination: string | undefined = environment.InitializationString;

  constructor(
    public router: Router,
    public system_MembershipService: System_MembershipService,
  ) {
    this.getByQueryString();
  }
  ngOnInit() {
  }
  getByQueryString() {
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        this.queryString = event.url;
        localStorage.setItem('URL', this.queryString);
      }
    });
  }
  onLogin() {
    if (localStorage.getItem('URL') != null) {
      this.urlDestination = localStorage.getItem('URL')?.toString();
      this.system_MembershipService.authenticationByEmailAndPasswordAndURL(this.email, this.password, this.urlDestination).then(res => {
        if (res) {
          this.system_MembershipService.formData = (res as System_Membership);
          if (this.system_MembershipService.formData.CodeManage) {
            localStorage.setItem('MembershipID', "" + this.system_MembershipService.formData.ID);
            localStorage.setItem('AuthenticationToken', "" + this.system_MembershipService.formData.Note);            
            window.location.href = "" + this.system_MembershipService.formData.CodeManage;
          }
          else {
            alert(environment.LoginNotSuccess);
          }
        }
        else {
          alert(environment.LoginNotSuccess);
        }
      });
    }
    else {
      alert(environment.LoginNotSuccess);
    }
  }
}
