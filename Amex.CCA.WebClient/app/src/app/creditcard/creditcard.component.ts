import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { CrediCardService } from '../services/creditcard.service'
import { ICreditCard } from "../models/creditcard";
import { ICardType } from "../models/cardtype";
import { INationality } from "../models/nationality";
import { IAttachments } from "../models/attachments";
import { IAttachmentType } from "../models/attachment-type";

@Component({
    templateUrl: './creditcard.template.html',
    styleUrls: ['./creditcard.styles.scss']
})
export class CreditCardComponent implements OnInit {
    private ccForm: FormGroup;
    private attachments: IAttachments[] = [];
    private attTypes: IAttachmentType[] = [];
    cardTypes: ICardType[];
    nationalities: INationality[];
    selectedCardType: ICardType;
    selectedNationality:INationality;
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
            email: ['pmd@tiqri.com', Validators.required],
            employer: ['employer', Validators.required],
            salary: ['100.00', Validators.required],
            jobTitle: ['jobTitle', Validators.required],
            cardLimit: ['200.00'],
            cashLimit: ['150.00'],
            note: ['note'],
            cardType: [Validators.required],
            nationality: [Validators.required],
            nicAttachments: [],
            salSlipAttachments: [],
            billingProofAttachments: []
        });
        this.loadCardTypes();
        this.loadAttachmentTypes();
        this.actRouter.data.forEach(data => {
            this.nationalities = data['nationality'];
            this.selectedNationality=this.nationalities[0];
        });
    }

    private loadAttachmentTypes(): void {
        this.crediCardService.getAttachmentTypes().subscribe((attTypes: IAttachmentType[]) => {
            this.attTypes = attTypes;
            console.log(this.attTypes);

        }, error => console.log(error));
    }

    private onFileSelect(key, event: Event) {
        let fileList: FileList = event.target['files'];
        this.attachments.push({ key: key, fileList: fileList });
        console.log(this.attachments);
    }
    private loadCardTypes(): void {
        this.crediCardService.getCardTypes().subscribe((cardTypes: ICardType[]) => {
            this.cardTypes = cardTypes;
            this.selectedCardType=cardTypes[0];
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
                CardTypeId: creditCardFormValues['cardType']['CardTypeId'],
                NationalityId: creditCardFormValues['nationality']['NationalityId'],
                Note: creditCardFormValues['note'],
                Attachments: this.attachments,
                CreditCardId: 0
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
