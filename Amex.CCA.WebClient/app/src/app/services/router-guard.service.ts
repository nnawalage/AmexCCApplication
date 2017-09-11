import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router } from "@angular/router";
import { LoginService } from "./index";

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private loginService: LoginService, private router: Router) {

    }

    canActivate(route: ActivatedRouteSnapshot) {
        let isUserAuthorized = this.loginService.isUserAuthorised();
        if (!isUserAuthorized) {
            this.router.navigate(['login']);
        }
        return isUserAuthorized;
        
    }
}