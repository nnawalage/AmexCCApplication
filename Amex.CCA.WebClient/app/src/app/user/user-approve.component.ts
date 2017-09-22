import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service'
import { UserApprove } from '../models/userApprove'

@Component({
    selector: 'user-approve',
    templateUrl: './user-approve.template.html',
    styleUrls: ['./user-approve.styles.scss']
})
export class UserApproveComponent implements OnInit {
    constructor(private userService: UserService) { }
    private profileImage: string;
    usersToApprove: UserApprove[] = []

    getInActiveUsers(): void{
            this.userService.getUsersToApprove()
                            .subscribe(users=>{
                                this.usersToApprove = users
                                console.log(this.usersToApprove);
                            });
    }
    ngOnInit(): void {
        this.getInActiveUsers();
    }
}