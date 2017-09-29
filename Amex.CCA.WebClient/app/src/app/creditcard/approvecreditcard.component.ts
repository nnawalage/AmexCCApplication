import { Component } from '@angular/core';
import { DialogComponent, DialogService } from "ng2-bootstrap-modal";
import { FormsModule } from '@angular/forms';
import { ICreditCard } from '../models/creditcard';
import { CrediCardService } from "../services/creditcard.service";
import { IReviewComment } from "../models/reviewcomment";
import { IUser } from "../models/user";
import { LoginService } from "../services/login.service";

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
    loggedUser: IUser;
    IsAdmin: boolean = false;
    IsStaff: boolean = false;

    constructor(dialogService: DialogService, private crediCardService: CrediCardService, private loginService: LoginService) {
        super(dialogService);
        this.loggedUser = this.loginService.loggedUser;
        this.IsAdmin = this.loggedUser.Role == 'Admin' ? true : false;
        this.IsStaff = this.loggedUser.Role == 'Staff' ? true : false;
    }

    ngOnInit() {
        this.CreditCard = new Object();
        document.getElementsByTagName('body')[0].classList.add('modal-open');

        this.crediCardService.getCardDetails(this.CreditCardId).subscribe((creditCard: ICreditCard) => {
            console.log(creditCard);
            this.CreditCard = creditCard;
        }, error => console.log(error));
    }

    review(action: string) {
        this.ReviewComment = {
            CreditCardId: this.CreditCardId,
            ReviewerComment: this.CreditCard.ReviewerComment
        }
        if (action === "Approved") { this.ReviewComment.IsApproved = true; }
        else if (action === "Performed") { this.ReviewComment.IsPerformed = true; }
        else if (action === "Rejected") { this.ReviewComment.IsRejected = true; }

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
