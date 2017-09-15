import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
// import { CrediCardService } from '../services/index';
import { CrediCardService } from '../services/creditcard.service';


@Injectable()
export class NationalityResolverService implements Resolve<any>{
    constructor(private creditCardService: CrediCardService) { }

    resolve(router: ActivatedRouteSnapshot) {
        return this.creditCardService.getNationalities();
    }

}