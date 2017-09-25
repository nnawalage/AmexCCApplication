import { NgModule } from '@angular/core';;
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './login.component';

const loginRoute: Routes = [
    { path: '', component: LoginComponent, pathMatch: 'full' }
]

@NgModule({
    imports: [
        FormsModule,
        RouterModule.forChild(loginRoute)
    ],
    declarations: [LoginComponent],
    providers: []
})
export class LoginModule {
}
