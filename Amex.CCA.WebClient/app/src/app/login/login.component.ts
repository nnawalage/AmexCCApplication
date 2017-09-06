import { Component } from '@angular/core';
import { LoginService } from '../services/login.service'
import { User } from "../models/user";

@Component({
    templateUrl: './login.template.html',
    styleUrls: ['./login.styles.scss'],

})
export class LoginComponent {

    constructor(private loginService: LoginService) {

    }

    private onLoginSubmit(loginFormValues: Object): void {
        console.log(loginFormValues);
        let user: User = {
            UserName: loginFormValues['txtUserName'],
            PassWord: loginFormValues['txtPassWord']
        }

        this.loginService.GetUser(user).subscribe(res => {
            console.log(res);
        }, error => console.log(error))
    }


}