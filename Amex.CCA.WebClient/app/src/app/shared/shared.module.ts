import { NgModule } from '@angular/core';
import { HeaderComponent } from './header.component';
import { FooterComponent } from "./footer.component";
import { UserProfileComponent } from '../user/user-profile.component';
import { CommonModule } from '@angular/common';

@NgModule({
    imports: [],
    declarations: [HeaderComponent, FooterComponent, UserProfileComponent],
    providers: [],
    exports: [HeaderComponent, FooterComponent]
})
export class SharedModule {
}
