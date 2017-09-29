import { Component, Input } from '@angular/core';
import { IUser } from '../models/user';
@Component({
    selector: 'header',
    templateUrl: './header.template.html',
    styleUrls: ['./header.styles.scss']
})
export class HeaderComponent {
    @Input() user: IUser;
}
