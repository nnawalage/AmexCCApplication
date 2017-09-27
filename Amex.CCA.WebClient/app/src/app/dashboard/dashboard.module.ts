import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { dashBoardRoutes } from './dashboard.routes';
import { DashboardComponent } from './dashboard.component';
import { BootstrapModalModule } from 'ng2-bootstrap-modal';
import { CreditCardModule } from '../creditcard/creditcard.module';

@NgModule({
    imports: [CommonModule,
        BootstrapModalModule,
        CreditCardModule,
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
