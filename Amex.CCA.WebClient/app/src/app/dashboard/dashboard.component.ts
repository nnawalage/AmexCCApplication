import {Component} from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { CrediCardService } from "../services/creditcard.service";
import { Router } from "@angular/router";
import { FormsModule } from '@angular/forms';
import { ICreditCardView } from "../models/creditcardview";


@Component({
templateUrl:'./dashboard.template.html',
styleUrls:['./dashboard.styles.scss']
})
export class DashboardComponent{
    cardRequestList: ICreditCardView[];
    cardRequest: ICreditCardView;
 constructor(private actRouter: ActivatedRoute, private router: Router, private crediCardService: CrediCardService) {
 }

 ngOnInit() {
     this.crediCardService.getAllCardRequests().subscribe(receivedCardRequests => {
         this.cardRequestList= receivedCardRequests;
         console.log(this.cardRequestList)
         }, error => console.log(error));
 }


 //clickRequest() {
 //    let expandableStatus: boolean = this.cardRequest.IsExpandable;
 //    this.cardRequest.IsExpandable = !expandableStatus;
     
 //}
}
