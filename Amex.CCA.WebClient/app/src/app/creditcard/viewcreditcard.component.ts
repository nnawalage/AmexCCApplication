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
        this.crediCardService.getCardDetails(this.CreditCardId).subscribe((creditCard: ICreditCard) => {
            console.log(creditCard);
            this.CreditCardId = creditCard.CreditCardId;
            this.FullName = creditCard.FullName;
            this.DisplayName = creditCard.DisplayName;
            this.Nic = creditCard.Nic;
            this.Passport = creditCard.Passport;
            this.Address = creditCard.Address;
            this.MobilePhone = creditCard.MobilePhone;
            this.HomePhone = creditCard.HomePhone;
            this.OfficePhone = creditCard.OfficePhone;
            this.Email = creditCard.Email;
            this.Employer = creditCard.Employer;
            this.Salary = creditCard.Salary;
            this.JobTitle = creditCard.JobTitle;
            this.CardLimit = creditCard.CardLimit;
            this.CashLimit = creditCard.CashLimit;
            this.Note = creditCard.Note;
            this.CardTypeId = creditCard.CardTypeId;
            this.NationalityId = creditCard.NationalityId;

        }, error => console.log(error));
    }

    apply() {
        //this.result = this.message;
        this.close();
    }
}
