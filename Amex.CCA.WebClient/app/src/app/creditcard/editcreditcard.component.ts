import { Component } from '@angular/core';
import { DialogComponent, DialogService } from "ng2-bootstrap-modal";
import { FormsModule } from '@angular/forms';
import {ICreditCard} from '../models/creditcard';
import { CrediCardService } from "../services/creditcard.service";
import { ICardType } from "../models/cardtype";
import { INationality } from "../models/nationality";

export interface PromptModel {
    CreditCard: ICreditCard;
    CreditCardId: number;
}

@Component({
    selector: 'prompt',
    templateUrl: './editcreditcard.template.html'
})
export class EditCreditCardComponent extends DialogComponent<PromptModel, string> implements PromptModel {
    cardTypes: ICardType[];
    selectedCardType: ICardType;
    nationalities: INationality[];
    selectedNationality: INationality;
    response: any;


    CreditCard: any;
    CreditCardId: number;

    constructor(dialogService: DialogService, private crediCardService: CrediCardService) {
        super(dialogService);
    }

    ngOnInit() {
        this.CreditCard = new Object();
        document.getElementsByTagName('body')[0].classList.add('modal-open');
        this.crediCardService.getCardDetails(this.CreditCardId).subscribe((creditCard: ICreditCard) => {
            console.log(creditCard);
            this.CreditCard = creditCard;
            this.loadCardTypes();
            this.loadNationalityTypes();
        }, error => console.log(error));
    }

    ngOnDestroy() {
        document.getElementsByTagName('body')[0].classList.remove('modal-open');
    }

    private loadCardTypes(): void {
        this.crediCardService.getCardTypes().subscribe((cardTypes: ICardType[]) => {
            this.cardTypes = cardTypes;
            this.selectedCardType = cardTypes.filter(
                cardType => cardType.CardTypeId === this.CreditCard.CardTypeId)[0];
        }, error => console.log(error));
    }

    private loadNationalityTypes(): void {
        this.crediCardService.getNationalities().subscribe((nationalityTypes: INationality[]) => {
            this.nationalities = nationalityTypes;
            this.selectedNationality = nationalityTypes.filter(
                nation => nation.NationalityId === this.CreditCard.NationalityId)[0];
        }, error => console.log(error));
    }

     save() {
        //this.result = this.message;

        this.CreditCard.CardTypeId = this.selectedCardType.CardTypeId;
        this.CreditCard.NationalityId = this.selectedNationality.NationalityId;

        this.crediCardService.SaveCreditCard(this.CreditCard).subscribe((res: any) => {
            this.response = res;
            console.log(res);
        }, error => {
            console.log('error when saving' + error);
        });

        this.close();
    }
}
