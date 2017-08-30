import { Routes } from '@angular/router';
// import { DashboardComponent } from './dashboard/dashboard.component';

export const appRoutes: Routes = [
    //  { path: '', redirectTo: 'abc' ,pathMatch:'full'},
    { path: 'dashboard',loadChildren:'./dashboard/dashboard.module#DashboardModule' },
    {path:'user',loadChildren:'./user/user.module#UserModule'}  
]