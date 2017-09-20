import { Component, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';
import { IUser } from "../models/Iuser";

@Component({
    templateUrl: './login.template.html',
    styleUrls: ['./login.styles.scss'],
})
export class LoginComponent {
    loginInvalid: boolean = false;

    constructor(private router: Router, private loginService: LoginService) {

    }

    private onLoginSubmit(loginFormValues: Object): void {
        console.log(loginFormValues);
        let user: IUser = {
            UserName: loginFormValues['txtUserName'],
            PassWord: loginFormValues['txtPassword']
        }

        this.loginService.loginUser(user).subscribe((res: IUser) => {
            this.loginService.getProfile(res).subscribe((resUser: IUser) => {
                this.loginService.loggedUser.ProfileName = resUser.ProfileName;
                this.loginService.loggedUser.ProfileImage = resUser.ProfileImage;
                sessionStorage.setItem('authData', JSON.stringify(this.loginService.loggedUser));
                this.router.navigate(['dashboard/myWork']);
            }, error => console.log(error));
        }, error => {
            //console.log('errCame' + error);
        });

    }


}
