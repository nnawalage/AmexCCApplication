import { Component } from '@angular/core';
import { DialogComponent, DialogService } from "ng2-bootstrap-modal";
import { FormsModule } from '@angular/forms';
import { ICreditCard } from '../models/creditcard';
import { CrediCardService } from "../services/creditcard.service";
import { IReviewComment } from "../models/reviewcomment";

export interface PromptModel {
    CreditCard: ICreditCard;
    CreditCardId: number;
}

@Component({
    selector: 'prompt',
    templateUrl: './approvecreditcard.template.html'
})
export class ApproveCreditCardComponent extends DialogComponent<PromptModel, string> implements PromptModel {

    CreditCard: any;
    CreditCardId: number;
    ReviewComment: IReviewComment;

    constructor(dialogService: DialogService, private crediCardService: CrediCardService) {
        super(dialogService);
    }

    ngOnInit() {
        this.CreditCard = new Object();
        document.getElementsByTagName('body')[0].classList.add('modal-open');

        this.crediCardService.getCardDetails(this.CreditCardId).subscribe((creditCard: ICreditCard) => {
            console.log(creditCard);
            this.CreditCard = creditCard;
        }, error => console.log(error));
    }
    review(isApproved: boolean) {
        debugger;
        this.ReviewComment = {
            CreditCardId: this.CreditCardId,
            ReviewerComment: "ReviewerComment",
            IsApproved: isApproved
        }

        this.crediCardService.SaveReviewComment(this.ReviewComment).subscribe((res: any) => {
            console.log(res);
        }, error => {
            console.log('error when saving' + error);
        });


        this.close();
    }

    ngOnDestroy() {
        document.getElementsByTagName('body')[0].classList.remove('modal-open');
    }
}
