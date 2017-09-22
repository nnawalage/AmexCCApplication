import {NgModule} from '@angular/core';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import {userRoutes} from './user.routes';
import {EditProfileComponent} from './edit-profile.component';
import {UserRegistrationComponent} from './user-registration.component'
import { CommonModule } from '@angular/common';

@NgModule({
    imports:[
        RouterModule.forChild(userRoutes),
        CommonModule,
        ReactiveFormsModule
    ],
    declarations:[
        EditProfileComponent,
        UserRegistrationComponent
    ],
    providers:[]
})
export class UserModule{

}
      