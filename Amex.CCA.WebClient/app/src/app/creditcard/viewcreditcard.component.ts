import { Component } from '@angular/core';
import { DialogComponent, DialogService } from "ng2-bootstrap-modal";
import { FormsModule } from '@angular/forms';
import {ICreditCard} from '../models/creditcard';
import { CrediCardService } from "../services/creditcard.service";

export interface PromptModel {
    CreditCard: ICreditCard;
    CreditCardId: number;
}

@Component({
    selector: 'prompt',
    templateUrl: './viewcreditcard.template.html'
})
export class ViewCreditCardComponent extends DialogComponent<PromptModel, string> implements PromptModel {
    CreditCard: any;
    CreditCardId: number;

    constructor(dialogService: DialogService, private crediCardService: CrediCardService) {
        super(dialogService);
    }

    ngOnInit() {
        this.CreditCard = new Object();
        this.crediCardService.getCardDetails(this.CreditCardId).subscribe((creditCard: ICreditCard) => {
            console.log(creditCard);
            this.CreditCard = creditCard;
        }, error => console.log(error));
    }

    apply() {
        //this.result = this.message;
        this.close();
    }
}
