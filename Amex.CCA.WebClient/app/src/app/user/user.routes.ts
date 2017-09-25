import { Routes } from '@angular/router';
import { EditProfileComponent } from './edit-profile.component';
import { UserRegistrationComponent } from './user-registration.component'

export const userRoutes: Routes = [
    { path: 'editProfile', component: EditProfileComponent },
    { path: 'registration', component: UserRegistrationComponent }
]