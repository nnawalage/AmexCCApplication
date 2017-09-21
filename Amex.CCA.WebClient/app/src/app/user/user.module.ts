import {NgModule} from '@angular/core';
import {RouterModule} from '@angular/router';
import {userRoutes} from './user.routes';
import {EditProfileComponent} from './edit-profile.component';
import {UserRegistrationComponent} from './user-registration.component'


@NgModule({
    imports:[
     RouterModule.forChild(userRoutes)
    ],
    declarations:[
        EditProfileComponent,
        UserRegistrationComponent
    ],
    providers:[]
})
export class UserModule{

}
      