import { NgModule } from '@angular/core';;
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CreditCardComponent } from './creditcard.component';


const crediCardRoute: Routes = [
    { path: '', component: CreditCardComponent, pathMatch: 'full' }
]

@NgModule({
    imports: [
        FormsModule,
        RouterModule.forChild(crediCardRoute)
    ],
    declarations: [CreditCardComponent],
    providers: []

})
export class CreditCardModule {

}