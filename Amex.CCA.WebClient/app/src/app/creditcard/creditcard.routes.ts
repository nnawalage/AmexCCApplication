import { Routes } from '@angular/router';
import { CreditCardComponent } from './creditcard.component';
import { AuthGuard } from "../index";

export const creditCardRoutes: Routes = [
    { path: 'creditcard', component: CreditCardComponent }
];

