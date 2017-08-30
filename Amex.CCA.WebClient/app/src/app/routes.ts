import { Routes } from '@angular/router';

export const appRoutes: Routes = [
     { path: 'dashboard',loadChildren:'./dashboard/dashboard.module#DashboardModule' },
     {path:'user',loadChildren:'./user/user.module#UserModule'}  
]