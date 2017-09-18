import {Component} from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { CrediCardService } from "../services/creditcard.service";
import { Router } from "@angular/router";
import { FormsModule } from '@angular/forms';
import { CreditCard } from "../models/creditcard";


@Component({
templateUrl:'./dashboard.template.html',
styleUrls:['./dashboard.styles.scss']
})
export class DashboardComponent{
    cardRequestList: CreditCard[];
 constructor(private actRouter: ActivatedRoute, private router: Router, private crediCardService: CrediCardService) {
 }

 ngOnInit() {
     this.crediCardService.getAllCardRequests().subscribe(receivedCardRequests => {
         this.cardRequestList = receivedCardRequests;
         console.log(this.cardRequestList)
         }, error => console.log(error));
     let a = 5;
    
    }
}
