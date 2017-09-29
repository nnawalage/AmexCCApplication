import { Component, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';
import { IUser } from "../models/user";

@Component({
    templateUrl: './login.template.html',
    styleUrls: ['./login.styles.scss'],
})
export class LoginComponent {
    loginInvalid: boolean = false;
    txtUserName: string;
    txtPassword: string;
    constructor(private router: Router, private loginService: LoginService) {
    }

    onLoginSubmit(loginFormValues: Object): void {
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
                switch (this.loginService.loggedUser.Role) {
                    case "Staff": {
                        this.router.navigate(['dashboard/myWork']);
                        break;
                    }
                    case "Admin": {
                        this.router.navigate(['dashboard/myApproval']);
                        break;
                    }
                    case "User": {
                        this.router.navigate(['dashboard/myRequest']);
                        break;
                    }
                    default: {
                        this.router.navigate(['login']);
                        break;
                    }
                }
            }, error => console.log(error));
        }, error => {
            //console.log('errCame' + error);
        });
    }

    onRegisterClick() {
        this.router.navigate(['user/registration'])
    }
}
