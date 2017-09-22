import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { userRoutes } from './user.routes';
import { EditProfileComponent } from './edit-profile.component';

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule.forChild(userRoutes)
    ],
    declarations: [
        EditProfileComponent,
    ],
    providers: []
})
export class UserModule {

}
