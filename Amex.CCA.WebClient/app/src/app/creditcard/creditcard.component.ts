import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { CrediCardService } from '../services/creditcard.service'
import { CreditCard } from "../models/creditcard";



@Component({
    templateUrl: './creditcard.template.html',
    styleUrls: ['./creditcard.styles.scss']
})
export class CreditCardComponent implements OnInit {
    private ccForm: FormGroup;
    // private nameInFull: FormControl;
    // private displayName: FormControl;

    private for

    constructor(private router: Router, private crediCardService: CrediCardService, private _fb: FormBuilder) {
    }

    ngOnInit() {
        this.ccForm = this._fb.group({
            nameInFull: ['', [Validators.required]],
            displayName: ['',Validators.required]
        });
    }

    private onSubmit(creditCardFormValues: Object): void {
        console.log(this.ccForm.valid);
        if (this.ccForm.valid) {
            let creditCard: CreditCard = {
                FullName: creditCardFormValues['nameInFull'],
                DisplayName: creditCardFormValues['displayName']
            }

            this.crediCardService.SaveCreditCard(creditCard).subscribe((res: any) => {
                console.log(res);
            }, error => {
                console.log('error when saving' + error);
            });

        }

    }
}
