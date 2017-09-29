import { Injectable, EventEmitter } from '@angular/core'
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

    getProfile(user: IUser): Observable<IUser> {
        let url: string = `/UserProfiles/GetUserProfile/${user.UserName}/`;
        //let url: string = `/UserProfiles/GetUserProfile/pmd@tiqri.com/`;
        return this._http.get(url).map((res: Response) => {
            return <IUser>res.json();
        });
        //let emitter = new EventEmitter(true);
        //let result: IUser = {
        //    ProfileName: 'Test User',
        //    ProfileImage: ''
        //}
        //setTimeout(() => {
        //    emitter.emit(result);
        //}, 100);
        //return emitter;
    }

    loginUser(user: IUser): Observable<IUser> {
        let url = `${this.baseUri}/Token`;
        let grantType: string = 'password';
        let creds: string = `grant_type=${grantType}&userName=${user.UserName}&password=${user.PassWord}`;
        let headers: any = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        let options = new RequestOptions({ headers: headers });
        // this.loggedUser.ProfileImage = '../../../assets/images/no-image.png';
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
                this.getProfile(user).subscribe((resUser: IUser) => {
                    this.loggedUser.ProfileName = resUser.ProfileName;
                    this.loggedUser.ProfileImage = resUser.ProfileImage;
                    this.loggedUser.UserProfileId = resUser.UserProfileId;

                    sessionStorage.setItem('authData', JSON.stringify(this.loggedUser));
                }, error => console.log(error));

                return user;
            }).catch(this.handleError);
    }

    private handleError(error: Response) {
        console.log(error);
        return Observable.throw(error.json() || 'Server error');
    }
}
