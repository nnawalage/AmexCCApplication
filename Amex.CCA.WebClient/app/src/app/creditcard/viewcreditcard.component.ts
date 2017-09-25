﻿import { Component } from '@angular/core';
import { DialogComponent, DialogService } from "ng2-bootstrap-modal";
import { FormsModule } from '@angular/forms';

export interface PromptModel {
    question: string;
}

@Component({
    selector: 'prompt',
    templateUrl: './viewcreditcard.template.html'
})
export class ViewCreditCardComponent extends DialogComponent<PromptModel, string> implements PromptModel {
    question: string;
    message: string = '';
    constructor(dialogService: DialogService) {
        super(dialogService);
    }
    apply() {
        this.result = this.message;
        this.close();
    }
}