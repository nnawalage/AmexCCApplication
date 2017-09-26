import { Component } from '@angular/core';
import { DialogComponent, DialogService } from "ng2-bootstrap-modal";
import { FormsModule } from '@angular/forms';
import {ICreditCard} from '../models/creditcard';
import { CrediCardService } from "../services/creditcard.service";

@Component({
    selector: 'prompt',
    templateUrl: './viewcreditcard.template.html'
})
export class ViewCreditCardComponent extends DialogComponent<ICreditCard, string> implements ICreditCard {
    question: string;
    message: string = 'ddddd';
    CreditCardId: number;
    FullName: string ='ddsdsds';
    DisplayName: string;
    Nic: string;
    Passport: string;
    Address: string;
    MobilePhone: string;
    HomePhone: string;
    OfficePhone: string; 
    Email: string;
    Employer: string;
    Salary: number;
    JobTitle: string;
    CardLimit: number;
    CashLimit: number;
    Note: string;
    CardTypeId: number;
    NationalityId: number;

    constructor(dialogService: DialogService, private crediCardService: CrediCardService) {
        super(dialogService);
    }

    ngOnInit() {
        this.crediCardService.getCardDetails(this.CreditCardId).subscribe(receivedCardRequests => {
            debugger;
            //this.cardRequestList = receivedCardRequests;
            //this.selectedIndex = 0;
        }, error => console.log(error));
    }

    apply() {
        //this.result = this.message;
        this.close();
    }
}
