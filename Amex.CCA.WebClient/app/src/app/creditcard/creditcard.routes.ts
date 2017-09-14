import { Routes } from '@angular/router';
import { CreditCardComponent } from './creditcard.component';
import { AuthGuard } from "../index";
import {NationalityResolverService} from '../services/nationality-resolver.service';
export const creditCardRoutes: Routes = [
    { path: '', component: CreditCardComponent,resolve:{nationality:NationalityResolverService},pathMatch:'full' }
    // { path: 'creditcard', component: CreditCardComponent}
    
];

