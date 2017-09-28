import { Routes } from '@angular/router';
// import { AuthGuard } from "./index";
import { AuthGuard } from "./services/router-guard.service";

export const appRoutes: Routes = [
    { path: 'dashboard', canActivate: [AuthGuard], loadChildren: './dashboard/dashboard.module#DashboardModule' },
    { path: 'user', canActivate: [AuthGuard], loadChildren: './user/user.module#UserModule' },
    { path: 'creditcard',canActivate: [AuthGuard], loadChildren: './creditcard/creditcard.module#CreditCardModule' },
    { path: 'login', loadChildren: './login/login.module#LoginModule',canActivate: [AuthGuard] },
    { path: '', redirectTo:'login', pathMatch:'full' },

    // { path: 'dashboard', loadChildren: './dashboard/dashboard.module#DashboardModule' },
    // { path: 'user', loadChildren: './user/user.module#UserModule' },
    // { path: 'creditcard', loadChildren: './creditcard/creditcard.module#CreditCardModule' },
    // { path: 'login', loadChildren: './login/login.module#LoginModule' },

]
