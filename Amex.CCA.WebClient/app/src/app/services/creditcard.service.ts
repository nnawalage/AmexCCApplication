import { Injectable } from '@angular/core'
import { ICreditCard } from '../models/creditcard';
import { Observable } from 'rxjs';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { ICardType } from "../models/cardtype";
import { INationality } from "../models/nationality";
// import { HttpService } from '../services/index';
import { HttpService } from '../services/http.service';
import { environment } from '../../environments/environment';
import { IAttachments } from "../models/attachments";
import { IAttachmentType } from "../models/attachment-type";

@Injectable()
export class CrediCardService {
    constructor(private http: HttpService) {
    }

    getAttachmentTypes(): Observable<IAttachmentType[]> {
      let attTypes:IAttachmentType[]=[];
        return this.http.get('/AttachmentTypes').map((response: Response) => {
            return <IAttachmentType[]>response.json();
        })
    }

    getCardTypes(): Observable<ICardType[]> {
        return this.http.get(`/CardType`).map((res: Response) => {
            return <ICardType[]>res.json();
        });
    }

    getNationalities(): Observable<INationality[]> {
        return this.http.get(`/Nationality`).map((res: Response) => {
            return <INationality[]>res.json();
        });
    }

    // SaveCreditCard(creditCard: CreditCard): Observable<any> {
    //     let url = `/CreditCards`;
    //     return this.http.post(url, creditCard);
    // }

    SaveCreditCard(creditCard: ICreditCard): Observable<any> {

        //let apiUrl = environment.baseURI + '/CreditCards/UploadFiles';
        let apiUrl = environment.baseURI + '/CreditCards';
        let token = this.getAuthToken();
        return Observable.create(observer => {

            let formData: FormData = new FormData(), xhr: XMLHttpRequest = new XMLHttpRequest();

            formData.append("FullName", creditCard.FullName);
            formData.append("DisplayName", creditCard.DisplayName);
            formData.append("Nic", creditCard.Nic);
            formData.append("Passport", creditCard.Passport);
            formData.append("Address", creditCard.Address);
            formData.append("MobilePhone", creditCard.MobilePhone);
            formData.append("HomePhone", creditCard.HomePhone);
            formData.append("OfficePhone", creditCard.OfficePhone);
            formData.append("Email", creditCard.Email);
            formData.append("Employer", creditCard.Employer);
            formData.append("Salary", creditCard.Salary.toString());
            formData.append("JobTitle", creditCard.JobTitle.toString());
            formData.append("CardLimit", creditCard.CardLimit.toString());
            formData.append("CashLimit", creditCard.CashLimit.toString());
            formData.append("CardTypeId", creditCard.CardTypeId.toString());
            formData.append("NationalityId", creditCard.NationalityId.toString());
            formData.append("Note", creditCard.Note);
            let attTypes: Object[] = [];
            creditCard.Attachments.forEach((attCat: IAttachments) => {
                for (let objKey in attCat.fileList) {
                    if (objKey != 'length' && objKey != 'item') {
                        formData.append("file", attCat.fileList[objKey]);
                        attTypes.push({ AttachmentTypeID: +attCat['key'], FileName: attCat.fileList[objKey]['name'] })
                    }
                }
            });
            formData.append("AttTypes", JSON.stringify(attTypes));
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

    getAllCardRequests(): Observable<ICreditCard[]> {
        return this.http.get('/CreditCards')
            .map((res: Response) => {
                return <ICreditCard[]>res.json()
            });
        // .catch((error: any) => Observable.throw(error.json().error || 'Server error'));
    }
}