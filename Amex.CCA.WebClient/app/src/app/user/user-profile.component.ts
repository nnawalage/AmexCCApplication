import { Component, OnInit } from '@angular/core';
import { LoginService } from '../services/index';

@Component({
    selector: 'user-profile',
    templateUrl: './user-profile.template.html',
    styleUrls: ['./user-profile.styles.scss']
})
export class UserProfileComponent implements OnInit {
    constructor(private loginService: LoginService) { }
    private profileImage: string;
    ngOnInit() {
        this.profileImage = '../../../assets/images/no-image.png';

        if (this.loginService.loggedUser.ProfileImage != null && this.loginService.loggedUser.ProfileImage != '') {
            this.profileImage = this.loginService.loggedUser.ProfileImage;
        }

    }
}