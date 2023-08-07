import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ShoppingCart } from 'src/app/shared/ShoppingCart.model';
import { ShoppingCartService } from 'src/app/shared/ShoppingCart.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { EmailService } from 'src/app/shared/Email.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  itemCount: number = environment.InitializationNumber;
  total: number = environment.InitializationNumber;
  volume: number = environment.InitializationNumber;
  constructor(
    public emailService: EmailService,
    public shoppingCartService: ShoppingCartService,
    public notificationService: NotificationService,

  ) { }
  ngOnInit(): void {
    this.getToList();
  }
  getToList() {
    this.isShowLoading = true;
    this.shoppingCartService.getBySearchStringToList(this.searchString).then(res => {
      this.shoppingCartService.list = res as ShoppingCart[];
      for (let i = 0; i < this.shoppingCartService.list.length; i++) {
        this.itemCount = this.itemCount + Number(this.shoppingCartService.list[i].ItemCount);         
        if(this.shoppingCartService.list[i].Total){
          let totalString=this.shoppingCartService.list[i].Total?.replace("$","");
          totalString=totalString?.replace(",","");
          this.total = this.total + Number(totalString);          
        }                      
        this.volume = this.volume + Number(this.shoppingCartService.list[i].Volume);
      }
      this.isShowLoading = false;
    });
  }
  onSearch() {
    this.getToList();
  }
  onSendMail(ID: any) {
    this.isShowLoading = true;
    this.emailService.asyncSendNotUserNameAndPasswordByShoppingCartForward(ID).then(
      res => {
        this.isShowLoading = false;
        this.notificationService.success(environment.SendMailSuccess);
      },
      err => {
        console.log(err);
        this.isShowLoading = false;
        this.notificationService.warn(environment.SendMailNotSuccess);
      }
    );
  }
}
