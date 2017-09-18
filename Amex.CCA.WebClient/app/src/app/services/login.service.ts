import { Injectable } from '@angular/core'
import { IUser } from '../models/user';
import { Observable } from 'rxjs';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Router } from '@angular/router';
import { HttpService } from "../services/http.service";
import { environment } from '../../environments/environment';

@Injectable()
export class LoginService {
    private baseUri: string = environment.baseURI;
    loggedUser: IUser = null;

    constructor(private http: Http, private _http: HttpService, private router: Router) {
    }

    refreshUser() {
        if (!this.loggedUser) {
            this.loggedUser = <IUser>JSON.parse(sessionStorage.getItem('authData'));
        }
    }

    isUserAuthorised(): boolean {
        return !!this.loggedUser
    }
    logOutUser() {
        this.loggedUser = null;
        sessionStorage.setItem('authData', null);
        this.router.navigate(['login']);
    }

    loginUser(user: IUser): Observable<IUser> {
        debugger;
        let url = `${this.baseUri}/Token`;
        let grantType: string = 'password';
        let creds: string = `grant_type=${grantType}&userName=${user.UserName}&password=${user.PassWord}`;
        let headers: any = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        let options = new RequestOptions({ headers: headers });

        return this.http.post(url, creds, options).map(
            (response: Response) => {
                let res: any = response.json();
                let user: IUser = {
                    UserName: res['userName'],
                    AccessToken: res['access_token'],
                    RefreshToken: res['refresh_token'],
                    UserExpires: res['.expires'],
                    RoleId: res['roleId'],
                    Role: res['role']
                };
                this.loggedUser = user;
                // sessionStorage.setItem('authData', JSON.stringify(res));
                sessionStorage.setItem('authData', JSON.stringify(user));
                return user;
            }).catch(this.handleError);
    }

    private handleError(error: Response) {
        console.log(error);
        return Observable.throw(error.json() || 'Server error');
    }
}