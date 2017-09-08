import { Component,ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service'
import { User } from "../models/user";
import { IToken } from '../models/token'

@Component({
    templateUrl: './login.template.html',
    styleUrls: ['./login.styles.scss'],
})
export class LoginComponent {

    constructor(private router: Router, private loginService: LoginService) {

    }

    private onLoginSubmit(loginFormValues: Object): void {
        console.log(loginFormValues);
        let user: User = {
            UserName: loginFormValues['txtUserName'],
            PassWord: loginFormValues['txtPassword']
        }

        this.loginService.GetUser(user).subscribe((res: IToken) => {
            sessionStorage.setItem('access-token', res.AccessToken);
            this.router.navigate(['dashboard/myWork']);

        }, error => {
            //console.log('errCame' + error);
        });
    }


}