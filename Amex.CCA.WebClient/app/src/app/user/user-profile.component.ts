import { Component, OnChanges, Input, OnInit } from '@angular/core';
import { LoginService } from '../services/index';
import { IUser } from '../models/user';

@Component({
    selector: 'user-profile',
    templateUrl: './user-profile.template.html',
    styleUrls: ['./user-profile.styles.scss']
})
export class UserProfileComponent implements OnInit {
    constructor(private loginService: LoginService) { }
    private profileImage: string;
    @Input() user: IUser;
    ngOnChanges() {
        this.profileImage = '../../../assets/images/no-image.png';
        //if (this.user.ProfileImage && this.user.ProfileImage !='abc') {
        this.profileImage = this.user.ProfileImage;
        //console.log(this.user.ProfileImage);
        //}
    }

    ngOnInit() {
        //this.profileImage = '../../../assets/images/no-image.png';
        // this.profileImage = '../../../assets/images/no-image.png';
        //// this.profileImage = this.loginService.loggedUser.ProfileImage;
        // this.profileImage =this.loginService.loggedUser.ProfileImage
        // if (this.loginService.loggedUser.ProfileImage != null && this.loginService.loggedUser.ProfileImage != '') {
        //     this.profileImage = this.loginService.loggedUser.ProfileImage;
        // }
    }
}
