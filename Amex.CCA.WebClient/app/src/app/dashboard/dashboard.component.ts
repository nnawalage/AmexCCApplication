import { Component } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { CrediCardService } from "../services/creditcard.service";
import { Router } from "@angular/router";
import { ICreditCard } from "../models/creditcard";
import { IUser } from "../models/user";
import { ViewCreditCardComponent } from '../creditcard/viewcreditcard.component';
import { EditCreditCardComponent } from '../creditcard/editcreditcard.component';
import { ApproveCreditCardComponent } from '../creditcard/approvecreditcard.component';
import { DialogService } from "ng2-bootstrap-modal";
import { LoginService } from "../services/login.service";


@Component({
    templateUrl: './dashboard.template.html',
    styleUrls: ['./dashboard.styles.scss']
})
export class DashboardComponent {

    loggedUser: IUser;
    //lsUser: boolean = false;
    IsAdmin: boolean = false;
    //lsStaff: boolean = false;

    cardRequestList: ICreditCard[];
    fullNameList: string[];
    displayNameList: string[];
    cardTypeList: string[];
    cardStatusList: string[];
    selectedIndex: number;
    cardRequestListTemp: ICreditCard[];
    promptMessage: string = '';
    creditCard: ICreditCard = null;
    constructor(private actRouter: ActivatedRoute, private router: Router, private crediCardService: CrediCardService, private dialogService: DialogService, private loginService: LoginService) {
        this.loggedUser = this.loginService.loggedUser;
        //this.lsUser = this.loggedUser.Role == 'User' ? true : false;
        this.IsAdmin = this.loggedUser.Role == 'Admin' ? true : false;
        //this.lsStaff = this.loggedUser.Role == 'Staff' ? true : false;
    }

    ngOnInit() {
        this.crediCardService.getAllCardRequests().subscribe(receivedCardRequests => {
            this.cardRequestList = receivedCardRequests;
            this.cardRequestListTemp = this.cardRequestList;
            this.selectedIndex = 0;
            if (this.cardRequestList.length != 0) {
                this.getFullNameFilterList(this.cardRequestList);
                this.getDisplayNameFilterList(this.cardRequestList);
                this.getCardTypeFilterList(this.cardRequestList);
                this.getCardStatusFilterList(this.cardRequestList);
            }
        }, error => console.log(error));
    }

    clickRequest(index: number) {
        this.selectedIndex = index;
    }

    openCreditCardView(cardId: number) {
        this.dialogService.addDialog(ViewCreditCardComponent, {
            CreditCard: this.creditCard,
            CreditCardId: cardId
        }).subscribe((message) => {
            //We get dialog result
            this.promptMessage = message;
        });
    }

    openCreditCardEdit(cardId: number) {
        this.dialogService.addDialog(EditCreditCardComponent, {
            CreditCard: this.creditCard,
            CreditCardId: cardId
        })
        .subscribe((message) => {
            //We get dialog result
            this.promptMessage = message;

        });
    }

    openCreditCardApprove(cardId: number) {
        this.dialogService.addDialog(ApproveCreditCardComponent, {
            CreditCard: this.creditCard,
            CreditCardId: cardId
        })
            .subscribe((message) => {
                //We get dialog result
                this.promptMessage = message;
            });
    }

    getFullNameFilterList(cardRequestList: ICreditCard[]) {
        this.fullNameList = [];
        let k: number = this.fullNameList.push(cardRequestList[0].FullName);
        for (let i: number = k; i < cardRequestList.length; i++) {
            for (let j: number = 0; j < k; j++) {
                if (this.fullNameList[j] === cardRequestList[i].FullName) {
                    j = k;
                }
                else if (j == (k - 1)) {
                    k = this.fullNameList.push(cardRequestList[i].FullName)
                }
            }
        }
    }

    getDisplayNameFilterList(cardRequestList: ICreditCard[]) {
        this.displayNameList = [];
        let k: number = this.displayNameList.push(cardRequestList[0].DisplayName);
        for (let i: number = k; i < cardRequestList.length; i++) {
            for (let j: number = 0; j < k; j++) {
                if (this.displayNameList[j] === cardRequestList[i].DisplayName) {
                    j = k;
                }
                else if (j == (k - 1)) {
                    k = this.displayNameList.push(cardRequestList[i].DisplayName)
                }
            }
        }
    }

    getCardTypeFilterList(cardRequestList: ICreditCard[]) {
        this.cardTypeList = [];
        let k: number = this.cardTypeList.push(cardRequestList[0].CardTypeName);
        for (let i: number = k; i < cardRequestList.length; i++) {
            for (let j: number = 0; j < k; j++) {
                if (this.cardTypeList[j] === cardRequestList[i].CardTypeName) {
                    j = k;
                }
                else if (j == (k - 1)) {
                    k = this.cardTypeList.push(cardRequestList[i].CardTypeName)
                }
            }
        }
    }

    getCardStatusFilterList(cardRequestList: ICreditCard[]) {
        this.cardStatusList = [];
        let k: number = this.cardStatusList.push(cardRequestList[0].CardStatusName);
        for (let i: number = k; i < cardRequestList.length; i++) {
            for (let j: number = 0; j < k; j++) {
                if (this.cardStatusList[j] === cardRequestList[i].CardStatusName) {
                    j = k;
                }
                else if (j == (k - 1)) {
                    k = this.cardStatusList.push(cardRequestList[i].CardStatusName)
                }
            }
        }
    }

    filterByCardType(cardType: string) {
        this.cardRequestList = this.cardRequestListTemp;
        let filtercardRequestList: ICreditCard[] = [];
        if (this.cardRequestList.length != 0) {
            for (let i: number = 0; i < this.cardRequestList.length; i++) {
                if (this.cardRequestList[i].CardTypeName == cardType) {
                    let k = filtercardRequestList.push(this.cardRequestList[i]);
                }
            }
            this.cardRequestListTemp = this.cardRequestList;
            this.cardRequestList = filtercardRequestList;
        }
    }

    filterByFullName(fullName: string) {
        this.cardRequestList = this.cardRequestListTemp;
        let filtercardRequestList: ICreditCard[] = [];
        if (this.cardRequestList.length != 0) {
            for (let i: number = 0; i < this.cardRequestList.length; i++) {
                if (this.cardRequestList[i].FullName == fullName) {
                    let k = filtercardRequestList.push(this.cardRequestList[i]);
                }
            }
            this.cardRequestListTemp = this.cardRequestList;
            this.cardRequestList = filtercardRequestList;
        }
    }

    filterByCardStatusName(cardStatusName: string) {
        this.cardRequestList = this.cardRequestListTemp;
        let filtercardRequestList: ICreditCard[] = [];
        if (this.cardRequestList.length != 0) {
            for (let i: number = 0; i < this.cardRequestList.length; i++) {
                if (this.cardRequestList[i].CardStatusName == cardStatusName) {
                    let k = filtercardRequestList.push(this.cardRequestList[i]);
                }
            }
            this.cardRequestListTemp = this.cardRequestList;
            this.cardRequestList = filtercardRequestList;
        }
    }

    filterByDisplayName(displayName: string) {
        this.cardRequestList = this.cardRequestListTemp;
        let filtercardRequestList: ICreditCard[] = [];
        if (this.cardRequestList.length != 0) {
            for (let i: number = 0; i < this.cardRequestList.length; i++) {
                if (this.cardRequestList[i].DisplayName == displayName) {
                    let k = filtercardRequestList.push(this.cardRequestList[i]);
                }
            }
            this.cardRequestListTemp = this.cardRequestList;
            this.cardRequestList = filtercardRequestList;
        }
    }
}
