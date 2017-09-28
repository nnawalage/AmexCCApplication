import { Injectable } from '@angular/core'
import { IUserProfile } from '../models/userprofile';
import { Observable } from 'rxjs';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { HttpService } from '../services/http.service';
import { LoginService } from '../services/login.service';
import { UserApprove } from '../models/userApprove';
import { Role }     from'../models/role';
import {IRegistration} from '../models/registration'
import { environment } from '../../environments/environment';
import { IAttachments } from "../models/attachments";

@Injectable()
export class UserProfileService {
    private headers = new Headers({ 'Content-Type': 'application/json' });
    constructor(private http: HttpService, private options: RequestOptions) { }

    getAllUserProfiles(): Observable<IUserProfile[]> {
        return this.http.get('/UserProfiles')
            .map((res: Response) => {
                return <IUserProfile[]>res.json()
            });
    }

    //THE DEFAULT METHOD IS NOT USING, BECAUSE OF IMAGE FILE ATTACHMENT
    //SaveUserProfile(userProfile: IUserProfile): Observable<any> {
    //    let url = `/UserProfiles`;
    //    return this.http.post(url, userProfile);
    //}

    SaveUserProfile(userProf: IUserProfile): Observable<any> {

        let apiUrl = environment.baseURI + '/UserProfiles';
        let token = this.getAuthToken();
        return Observable.create(observer => {

            let formData: FormData = new FormData(), xhr: XMLHttpRequest = new XMLHttpRequest();

            formData.append("UserName", userProf.UserName);
            formData.append("ProfileName", userProf.ProfileName);
            formData.append("ProfileImage", userProf.ProfileImage);
            formData.append("UserProfileID", userProf.userProfileId.toString());

           
            ////let attTypes: Object[] = [];
            userProf.Attachments.forEach((attCat: IAttachments) => {
                for (let objKey in attCat.fileList) {
                    if (objKey != 'length' && objKey != 'item') {
                        formData.append("file", attCat.fileList[objKey]);
                        //attTypes.push({ AttachmentTypeID: +attCat['key'], FileName: attCat.fileList[objKey]['name'] })
                    }
                }
            });

            //formData.append("AttTypes", JSON.stringify(attTypes));
            xhr.onreadystatechange = () => {
                if (xhr.readyState === 4) {
                    if (xhr.status === 201) {
                        observer.next(JSON.parse(xhr.response));
                        observer.complete();
                    } else {
                        observer.error(this.handleError);
                    }
                }
            };

            xhr.open('POST', apiUrl, true);
            xhr.setRequestHeader('Accept', 'application/json; charset=utf-8');
            xhr.setRequestHeader('Authorization', `Bearer ${token}`);

            xhr.send(formData);
        });
    }

    private getAuthToken() {
        let tokenObj = sessionStorage.getItem('authData');
        let key = JSON.parse(tokenObj);
        return key ? key.AccessToken : null;
    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Server error');
    }

    getUsersToApprove(): Observable <UserApprove[]>{
        let url=`/UserProfiles/approveUser`
        return this.http.get(url)
            .map((res: Response) => {
                return <UserApprove[]>res.json();
            });
    }
    getRoles(): Observable<Role[]> {
        let url = `/UserProfiles/roles`
        return this.http.get(url)
            .map((responce: Response) => {
                return <Role[]>responce.json();
            }
            )
    };
    saveApprovedUsers(userData: UserApprove, id: string): Observable<UserApprove[]> {
        let ApproveUrl = `/UserProfiles/approveUser`;
        let url = `${ApproveUrl}/${id}`;
        return this.http
            .post(url, JSON.stringify(userData))
            .map((responce: Response) => responce.json())
            .catch(this.handleError);

    }
    private handleError(error: any) {
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg);
        return Observable.throw(errMsg);
    }

    registerUser(user: IRegistration): Observable<any> {
        let url = `/Account/Register`;
        return this.http.post(url, user);
    }
}
