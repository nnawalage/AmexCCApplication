import { Injectable } from '@angular/core'
import { IUserProfile } from '../models/userprofile';
import { Observable } from 'rxjs';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { HttpService } from '../services/http.service';
import { LoginService } from '../services/login.service';
import { UserApprove } from '../models/userApprove';
import { Role }     from'../models/role';


@Injectable()
export class UserProfileService {
    constructor(private http: HttpService,private options:RequestOptions) { }

    getAllUserProfiles(): Observable<IUserProfile[]> {
        return this.http.get('/UserProfiles')
            .map((res: Response) => {
                return <IUserProfile[]>res.json()
            });
    }

    SaveUserProfile(userProfile: IUserProfile): Observable<any> {
        let url = `/UserProfiles`;
        return this.http.post(url, userProfile);
    }
    getUsersToApprove(): Observable <UserApprove[]>{
        let url=`/UserProfiles/approveUser`
        return this.http.get(url)
                        .map((res: Response) => {
                              return <UserApprove[]>res.json();
        });
    }
    getRoles(): Observable<Role[]>{
        let url=`/UserProfiles/roles`
        return this.http.get(url)
                        .map((responce:Response) => {
                        return   <Role[]>responce.json();
                        }
    )};
    saveApprovedUsers(userData:UserApprove,id:string): Observable<UserApprove[]>{
        
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        let ApproveUrl=`/UserProfiles/approveUser`;
        let url =`${ApproveUrl}/${id}`;
        console.log("saveApprovedUsers : ",userData);
        console.log("ID : ",id);
        return this.http
                    .patch(url,JSON.stringify(userData),{ headers:headers })
                    .map((responce: Response) => responce.json())
                    .catch(this.handleError);
        // return null;

    }
    private handleError(error: any) {
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg);
        return Observable.throw(errMsg);
    }

}