import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
// import { AuthGuard } from "../index";
import { AuthGuard } from "../services/router-guard.service";
export const dashBoardRoutes: Routes = [
    { path: 'myWork', component: DashboardComponent },
    { path: 'myRequest', component: DashboardComponent },
    { path: 'myApproval', component: DashboardComponent }
];
