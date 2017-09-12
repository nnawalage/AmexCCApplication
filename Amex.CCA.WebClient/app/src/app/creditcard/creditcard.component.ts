import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { CrediCardService } from '../services/creditcard.service'
import { CreditCard } from "../models/creditcard";
import { ICardType } from "../models/cardtype";


@Component({
    templateUrl: './creditcard.template.html',
    styleUrls: ['./creditcard.styles.scss']
})
export class CreditCardComponent implements OnInit {

    private ccForm: FormGroup;
     cardTypes: ICardType[];

    constructor(private router: Router, private crediCardService: CrediCardService, private _fb: FormBuilder) {
    }

    ngOnInit() {
        this.ccForm = this._fb.group({
            fullName: ['', [Validators.required]],
            displayName: ['', Validators.required],
            nic: ['', Validators.required],
            passport: ['', Validators.required],
            address: ['', Validators.required],
            mobilePhone: ['', Validators.required],
            homePhone: ['', Validators.required],
            officePhone: [''],
            email: ['', Validators.required],
            employer: ['', Validators.required],
            salary: ['', Validators.required],
            jobTitle: ['', Validators.required],
            cardLimit: [''],
            cashLimit: [''],
            note: [''],
            cardType: ['', Validators.required],
            nationality: ['', Validators.required]
        });
        this.loadCardTypes();
    }

    private loadCardTypes(): void {
        this.crediCardService.getCardTypes().subscribe((cardTypes: ICardType[]) => {
            this.cardTypes = cardTypes;
        }, error => console.log(error));
    }

    private onSubmit(creditCardFormValues: Object): void {
        console.log(this.ccForm.valid);
        if (this.ccForm.valid) {
            let creditCard: CreditCard = {
                FullName: creditCardFormValues['fullName'],
                DisplayName: creditCardFormValues['displayName'],
                Nic: creditCardFormValues['nic'],
                Passport: creditCardFormValues['passport'],
                Address: creditCardFormValues['address'],
                MobilePhone: creditCardFormValues['mobilePhone'],
                HomePhone: creditCardFormValues['homePhone'],
                OfficePhone: creditCardFormValues['officePhone'],
                Email: creditCardFormValues['email'],
                Employer: creditCardFormValues['employer'],
                Salary: creditCardFormValues['salary'],
                JobTitle: creditCardFormValues['jobTitle'],
                CardLimit: creditCardFormValues['cardLimit'],
                CashLimit: creditCardFormValues['cashLimit'],
                CardTypeId: creditCardFormValues['cardType'],
                NationalityId: creditCardFormValues['nationality'],
                Note: creditCardFormValues['note']
            }

            this.crediCardService.SaveCreditCard(creditCard).subscribe((res: any) => {
                console.log(res);
            }, error => {
                console.log('error when saving' + error);
            });

            //}

        }
    }
}
