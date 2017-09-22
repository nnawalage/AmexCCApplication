import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { dashBoardRoutes } from './dashboard.routes';
import { DashboardComponent } from './dashboard.component';
import { BootstrapModalModule } from 'ng2-bootstrap-modal';
import { CreditCardModule } from '../creditcard/creditcard.module';

@NgModule({
    imports: [CommonModule, FormsModule,
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
