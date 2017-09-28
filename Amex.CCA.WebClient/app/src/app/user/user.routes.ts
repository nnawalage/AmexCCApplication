import { Routes } from '@angular/router';
import { EditProfileComponent } from './edit-profile.component';
import { UserRegistrationComponent } from './user-registration.component'
import { UserApproveComponent } from './user-approve.component'
import { AuthGuard } from '../services/router-guard.service'

export const userRoutes: Routes = [
    { path: 'editProfile', component: EditProfileComponent },
    { path: 'user-approve', component: UserApproveComponent },
    { path: 'registration', component: UserRegistrationComponent /*,canActivate:[AuthGuard] */ }
]
