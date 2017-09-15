import { Component } from '@angular/core';
import { LoginService } from "../services/login.service";

@Component({
    selector: 'nav-bar',
    templateUrl: './navbar.template.html',
    styleUrls: ['./navbar.styles.scss']

})
export class NavBarComponent {
    constructor(private loginService: LoginService) { }
    onLogout() {
        this.loginService.logOutUser();
    }
}