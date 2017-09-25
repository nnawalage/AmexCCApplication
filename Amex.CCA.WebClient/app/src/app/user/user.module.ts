import {NgModule} from '@angular/core';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import {CommonModule} from '@angular/common';
import {userRoutes} from './user.routes';
import {EditProfileComponent} from './edit-profile.component';
import {UserRegistrationComponent} from './user-registration.component'
import { UserApproveComponent }    from './user-approve.component'

@NgModule({
    imports:[
        RouterModule.forChild(userRoutes),
        CommonModule,
        ReactiveFormsModule
    ],
    declarations: [
        EditProfileComponent,
        UserRegistrationComponent,
        UserApproveComponent
    ],
    providers: []
})
export class UserModule {
}
