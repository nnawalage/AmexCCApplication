import { Component } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { CrediCardService } from "../services/creditcard.service";
import { Router } from "@angular/router";
import { FormsModule } from '@angular/forms';
import { ICreditCard } from "../models/creditcard";

import { ViewCreditCardComponent } from '../creditcard/viewcreditcard.component';
import { EditCreditCardComponent } from '../creditcard/editcreditcard.component';
import { ApproveCreditCardComponent } from '../creditcard/approvecreditcard.component';
import { DialogService } from "ng2-bootstrap-modal";

@Component({
    templateUrl: './dashboard.template.html',
    styleUrls: ['./dashboard.styles.scss']
})
export class DashboardComponent {
    cardRequestList: ICreditCard[];
    selectedIndex: number;
    promptMessage: string = '';
    constructor(private actRouter: ActivatedRoute, private router: Router, private crediCardService: CrediCardService, private dialogService: DialogService) {
    }

    ngOnInit() {
        this.crediCardService.getAllCardRequests().subscribe(receivedCardRequests => {
            this.cardRequestList = receivedCardRequests;
            this.selectedIndex = 0;
        }, error => console.log(error));
    }

    clickRequest(index: number) {
        this.selectedIndex = index;
    }

    openCreditCardView(cardId: number) {
        debugger;
        this.dialogService.addDialog(ViewCreditCardComponent, {
            CreditCardId: cardId,
            //FullName :'dsdsdsdsdsvvvv'
        }).subscribe((message) => {
            //We get dialog result
            this.promptMessage = message;
        });
    }

    openCreditCardEdit() {
        this.dialogService.addDialog(EditCreditCardComponent, {
            question: 'What is your name?: '
        })
            .subscribe((message) => {
                //We get dialog result
                this.promptMessage = message;
            });
    }

    openCreditCardApprove() {
        this.dialogService.addDialog(ApproveCreditCardComponent, {
            question: 'What is your name?: '
        })
            .subscribe((message) => {
                //We get dialog result
                this.promptMessage = message;
            });
    }

    //clickRequest() {
    //    let expandableStatus: boolean = this.cardRequest.IsExpandable;
    //    this.cardRequest.IsExpandable = !expandableStatus;

    //}
}
