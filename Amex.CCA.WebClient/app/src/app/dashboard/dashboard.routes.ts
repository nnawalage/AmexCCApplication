import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { AuthGuard } from "../index";
export const dashBoardRoutes: Routes = [
    { path: 'myWork', component: DashboardComponent }
];

