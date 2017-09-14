﻿import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { CreditCardComponent } from './creditcard.component';
import {NationalityResolverService} from '../services/index';

const crediCardRoute: Routes = [
    { path: '', component: CreditCardComponent, pathMatch: 'full' }
]

@NgModule({
    imports: [CommonModule,
        ReactiveFormsModule,
        RouterModule.forChild(crediCardRoute)
    ],
    declarations: [CreditCardComponent],
    providers: [NationalityResolverService]

})
export class CreditCardModule {

}