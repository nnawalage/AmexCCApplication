import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router } from "@angular/router";
// import { LoginService } from "./index";
import { LoginService } from "../services/login.service";

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private loginService: LoginService, private router: Router) {
    }

    canActivate(route: ActivatedRouteSnapshot) {
        let isUserAuthorized = this.loginService.isUserAuthorised();
        // let componentName: string = route.component? route.component["name"]:'';

        // //if component name is available and component is UserRegistration or Login
        // //user should be navigated to the requested route only if the user is not logged in
        // if (componentName && (componentName=='UserRegistrationComponent'||componentName=='LoginComponent')) {
        //         return !isUserAuthorized;
        // }

        if (!isUserAuthorized) {
            this.router.navigate(['login']);
        }
        return isUserAuthorized;
    }
}
