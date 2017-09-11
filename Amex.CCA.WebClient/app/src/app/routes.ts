import { Routes } from '@angular/router';
import { AuthGuard } from "./index";

export const appRoutes: Routes = [
    { path: 'dashboard', canActivate: [AuthGuard], loadChildren: './dashboard/dashboard.module#DashboardModule' },
    { path: 'user', canActivate: [AuthGuard], loadChildren: './user/user.module#UserModule' },
    { path: 'creditcard',canActivate: [AuthGuard], loadChildren: './creditcard/creditcard.module#CreditCardModule' },
    { path: 'login', loadChildren: './login/login.module#LoginModule' },
   
]