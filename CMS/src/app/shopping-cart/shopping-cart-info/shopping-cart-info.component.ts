import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router, NavigationEnd } from '@angular/router';
import { NgForm } from '@angular/forms';
import { NotificationService } from 'src/app/shared/notification.service';
import { ShoppingCart } from 'src/app/shared/ShoppingCart.model';
import { ShoppingCartService } from 'src/app/shared/ShoppingCart.service';
import { ShoppingCart_Item } from 'src/app/shared/ShoppingCart_Item.model';
import { ShoppingCart_ItemService } from 'src/app/shared/ShoppingCart_Item.service';
import { EmailService } from 'src/app/shared/Email.service';

@Component({
  selector: 'app-shopping-cart-info',
  templateUrl: './shopping-cart-info.component.html',
  styleUrls: ['./shopping-cart-info.component.css']
})
export class ShoppingCartInfoComponent implements OnInit {

  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  constructor(
    public emailService: EmailService,
    public shoppingCartService: ShoppingCartService,
    public shoppingCart_ItemService: ShoppingCart_ItemService,
    public notificationService: NotificationService,
    public router: Router,   
  ) { 
    this.getByQueryString();
  }

  ngOnInit(): void {
  }
  getByQueryString() {
    this.isShowLoading = true;
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        this.queryString = event.url;
        this.shoppingCartService.getByID(this.queryString).then(res => {
          this.shoppingCartService.formData = res as ShoppingCart;                   
        });
        this.shoppingCart_ItemService.getByShoppingCart_IDToList(this.queryString).then(res => {
          this.shoppingCart_ItemService.list = res as ShoppingCart_Item[];                   
        });
        this.isShowLoading = false;
      }
    });
  }
  onSendMail(){
    this.isShowLoading = true;
    this.emailService.asyncSendNotUserNameAndPasswordByShoppingCartForward(this.queryString).then(
      res => {
        this.isShowLoading = false;
        this.notificationService.success(environment.SaveSuccess);                
      },
      err => {
        this.isShowLoading = false;
        this.notificationService.warn(environment.SaveNotSuccess);        
      }                 
    );
  }
}
