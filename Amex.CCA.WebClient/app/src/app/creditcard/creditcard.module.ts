import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { CreditCardComponent } from './creditcard.component';
// import {NationalityResolverService} from '../services/index';
import { NationalityResolverService } from '../services/nationality-resolver.service';
import { creditCardRoutes } from './creditcard.routes';

@NgModule({
    imports: [CommonModule,
        ReactiveFormsModule,
        RouterModule.forChild(creditCardRoutes)
    ],
    declarations: [CreditCardComponent],
    providers: [NationalityResolverService]
})
export class CreditCardModule {
}
