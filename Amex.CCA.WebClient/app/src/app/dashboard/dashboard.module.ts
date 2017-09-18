import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { dashBoardRoutes } from './dashboard.routes';
import { DashboardComponent } from './dashboard.component';
import { CommonModule } from '@angular/common'; 


@NgModule({
    imports: [CommonModule,
        RouterModule.forChild(dashBoardRoutes)
    ],
    declarations: [
         DashboardComponent
    ],
    providers: [
    ]
})


export class DashboardModule {

}
