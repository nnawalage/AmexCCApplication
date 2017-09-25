import { Routes } from '@angular/router';
import { CreditCardComponent } from './creditcard.component';
// import { AuthGuard } from "../index";
import { AuthGuard } from "../services/router-guard.service";

import { NationalityResolverService } from '../services/nationality-resolver.service';
export const creditCardRoutes: Routes = [
    { path: '', component: CreditCardComponent, resolve: { nationality: NationalityResolverService }, pathMatch: 'full' }
    // { path: 'creditcard', component: CreditCardComponent}

];
