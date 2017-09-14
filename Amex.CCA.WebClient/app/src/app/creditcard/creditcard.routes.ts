import { Routes } from '@angular/router';
import { CreditCardComponent } from './creditcard.component';
import { AuthGuard } from "../index";
import {NationalityResolverService} from '../services/nationality-resolver.service';
export const creditCardRoutes: Routes = [
    { path: 'creditcard', component: CreditCardComponent,resolve:{nationality:NationalityResolverService} }
    // { path: 'creditcard', component: CreditCardComponent}
    
];

