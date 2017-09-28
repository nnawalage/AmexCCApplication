import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginService } from "../services/login.service";
import { IUser } from "../models/user";

@Component({
    selector: 'nav-bar',
    templateUrl: './navbar.template.html',
    styleUrls: ['./navbar.styles.scss']
})
export class NavBarComponent {
    loggedUser: IUser;
    lsUser: boolean = false;
    IsAdmin: boolean = false;
    lsStaff: boolean = false;

    constructor(private loginService: LoginService) {
        this.loggedUser = this.loginService.loggedUser;
        this.lsUser = this.loggedUser.Role == 'User' ? true : false;
        this.IsAdmin = this.loggedUser.Role == 'Admin' ? true : false;
        this.lsStaff = this.loggedUser.Role == 'Staff' ? true : false;
    }

    onLogout() {
        this.loginService.logOutUser();
    }
}
