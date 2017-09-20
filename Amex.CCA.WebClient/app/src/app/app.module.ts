import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { appRoutes } from './routes';
import { UserModule } from './user/user.module';
import { SharedModule } from './shared/shared.module';
import { HttpModule, XHRBackend, RequestOptions } from '@angular/http';
// import {
//   NavBarComponent,
//   AuthGuard,
//   LoginService,
//   CrediCardService,
//   HttpService
// } from './index';

import {NavBarComponent} from './nav-bar/navbar.component';
import {AuthGuard} from './services/router-guard.service';
import {LoginService} from './services/login.service';
import {CrediCardService} from './services/creditcard.service';
import {HttpService} from './services/http.service';



 @NgModule({
  imports: [
    HttpModule,
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    SharedModule
  ],
  declarations: [
    AppComponent, NavBarComponent
  ],
  providers: [
    {
      provide: HttpService,
      useFactory: httpFactory,
      deps: [XHRBackend, RequestOptions]
    },
    LoginService,
    AuthGuard,
    CrediCardService,

    {
      provide: CrediCardService,
      useClass: CrediCardService
    }

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function httpFactory(backend: XHRBackend, options: RequestOptions) {
    return new HttpService(backend, options);
}
