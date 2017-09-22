import { Component } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { CrediCardService } from "../services/creditcard.service";
import { Router } from "@angular/router";
import { FormsModule } from '@angular/forms';
import { ICreditCard } from "../models/creditcard";

@Component({
    templateUrl: './dashboard.template.html',
    styleUrls: ['./dashboard.styles.scss']
})
export class DashboardComponent {
    cardRequestList: ICreditCard[];
    selectedIndex: number;
    constructor(private actRouter: ActivatedRoute, private router: Router, private crediCardService: CrediCardService) {
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
}
