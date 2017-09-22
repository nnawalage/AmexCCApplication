import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { CrediCardService } from '../services/creditcard.service'
import { ICreditCard } from "../models/creditcard";
import { ICardType } from "../models/cardtype";
import { INationality } from "../models/nationality";

@Component({
    templateUrl: './creditcard.template.html',
    styleUrls: ['./creditcard.styles.scss']
})
export class CreditCardComponent implements OnInit {
    private ccForm: FormGroup;
    cardTypes: ICardType[];
    nationalities: INationality[];

    constructor(private actRouter: ActivatedRoute, private router: Router, private crediCardService: CrediCardService, private _fb: FormBuilder) {
    }

    ngOnInit() {
        this.ccForm = this._fb.group({
            fullName: ['fullName', [Validators.required]],
            displayName: ['displayName', Validators.required],
            nic: ['nic', Validators.required],
            passport: ['passport', Validators.required],
            address: ['address', Validators.required],
            mobilePhone: ['232055222', Validators.required],
            homePhone: ['054552222', Validators.required],
            officePhone: [''],
            email: ['email', Validators.required],
            employer: ['employer', Validators.required],
            salary: ['100.00', Validators.required],
            jobTitle: ['jobTitle', Validators.required],
            cardLimit: ['200.00'],
            cashLimit: ['150.00'],
            note: ['note'],
            cardType: [Validators.required],
            nationality: [Validators.required]
        });
        this.loadCardTypes();

        this.actRouter.data.forEach(data => {
            this.nationalities = data['nationality'];
        });
    }

    private loadCardTypes(): void {
        this.crediCardService.getCardTypes().subscribe((cardTypes: ICardType[]) => {
            this.cardTypes = cardTypes;
        }, error => console.log(error));
    }

    private onSubmit(creditCardFormValues: Object): void {
        console.log(this.ccForm.valid);
        if (this.ccForm.valid) {
            let creditCard: ICreditCard = {
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
