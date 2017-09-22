import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from '@angular/router';
import {userRoutes} from './user.routes';
import {EditProfileComponent} from './edit-profile.component';
import {UserRegistrationComponent} from './user-registration.component'
import { UserApproveComponent }    from './user-approve.component'

@NgModule({
    imports:[CommonModule,
     RouterModule.forChild(userRoutes)
    ],
    declarations:[
        EditProfileComponent,
        UserRegistrationComponent,
        UserApproveComponent
    ],
    providers:[]
})
export class UserModule{

}
      