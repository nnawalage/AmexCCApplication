import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { LoginService } from "./services/login.service";

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    // encapsulation: ViewEncapsulation.None
})
export class AppComponent implements OnInit {
    constructor(public loginService: LoginService) { }
    title = 'app';
    ngOnInit() {
        this.loginService.refreshUser();
      
    }
}
