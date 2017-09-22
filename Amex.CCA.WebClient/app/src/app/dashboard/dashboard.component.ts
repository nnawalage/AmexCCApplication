import {Component} from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { CrediCardService } from "../services/creditcard.service";
import { Router } from "@angular/router";
import { ICreditCardView } from "../models/creditcardview";
import { ViewCreditCardComponent } from '../creditcard/viewcreditcard.component';
import { EditCreditCardComponent } from '../creditcard/editcreditcard.component';
import { ApproveCreditCardComponent } from '../creditcard/approvecreditcard.component';
import { DialogService } from "ng2-bootstrap-modal";

@Component({
    templateUrl: './dashboard.template.html',
    styleUrls: ['./dashboard.styles.scss']
})
export class DashboardComponent {
    cardRequestList: ICreditCardView[];
    cardRequest: ICreditCardView;
    promptMessage: string = '';

    constructor(private actRouter: ActivatedRoute, private router: Router, private crediCardService: CrediCardService, private dialogService: DialogService) {

    }

    ngOnInit() {
        this.crediCardService.getAllCardRequests().subscribe(receivedCardRequests => {
            this.cardRequestList = receivedCardRequests;
            console.log(this.cardRequestList)
        }, error => console.log(error));
    }

    openCreditCardView() {
        this.dialogService.addDialog(ViewCreditCardComponent, {
            question: 'What is your name?: '
        })
            .subscribe((message) => {
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
