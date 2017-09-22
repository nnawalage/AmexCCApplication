import {NgModule} from '@angular/core';
import {RouterModule} from '@angular/router';
import {userRoutes} from './user.routes';
import {EditProfileComponent} from './edit-profile.component';
@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule.forChild(userRoutes)
    ],
    declarations: [
        EditProfileComponent,
        UserRegistrationComponent
    ],
    providers: []
})
export class UserModule {

}
