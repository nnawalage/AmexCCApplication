import { Routes } from '@angular/router';
import { EditProfileComponent } from './edit-profile.component';
import { UserRegistrationComponent } from './user-registration.component'
import { UserApproveComponent }   from './user-approve.component'

export const userRoutes: Routes = [
    { path: 'editProfile', component: EditProfileComponent },
    { path: 'registration', component: UserRegistrationComponent },
    { path: 'user-approve', component: UserApproveComponent }
]