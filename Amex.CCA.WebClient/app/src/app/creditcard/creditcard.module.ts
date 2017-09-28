import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CreditCardComponent } from './creditcard.component';
import { NationalityResolverService } from '../services/nationality-resolver.service';
import { creditCardRoutes } from './creditcard.routes';

import { ViewCreditCardComponent } from '../creditcard/viewcreditcard.component';
import { EditCreditCardComponent } from '../creditcard/editcreditcard.component';
import { ApproveCreditCardComponent } from '../creditcard/approvecreditcard.component';

@NgModule({
    imports: [CommonModule, FormsModule,
        ReactiveFormsModule,
        RouterModule.forChild(creditCardRoutes)
    ],
    declarations: [
        CreditCardComponent, ViewCreditCardComponent, EditCreditCardComponent, ApproveCreditCardComponent
    ],
    providers: [NationalityResolverService],
    entryComponents: [
        ViewCreditCardComponent, EditCreditCardComponent, ApproveCreditCardComponent
    ],
    exports: [
        ViewCreditCardComponent, EditCreditCardComponent, ApproveCreditCardComponent
    ]
})
export class CreditCardModule {
}
