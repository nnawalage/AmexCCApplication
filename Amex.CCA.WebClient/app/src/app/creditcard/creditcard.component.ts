import { Component, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { CrediCardService } from '../services/creditcard.service'
import { CreditCard } from "../models/creditcard";
//import { IToken } from '../models/token'


@Component({
    templateUrl: './creditcard.template.html',
    styleUrls: ['./creditcard.styles.scss']
})
export class CreditCardComponent {
    ngOnInit() {
    }

    constructor(private router: Router, private crediCardService: CrediCardService) {
    }

    private onSubmit(creditCardFormValues: Object): void {
        console.log(creditCardFormValues);
        let creditCard: CreditCard = {
            FullName: creditCardFormValues['txtNameInFull'],
            DisplayName: creditCardFormValues['txtDisplayName']
        }

        this.crediCardService.SaveCreditCard(creditCard).subscribe((res: any) => {          
            console.log(res);
        }, error => {
            console.log('error when saving' + error);
        });
    }
}
