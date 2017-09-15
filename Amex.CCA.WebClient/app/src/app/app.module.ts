import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { appRoutes } from './routes';
import { UserModule } from './user/user.module';
import { SharedModule } from './shared/shared.module';
import { XHRBackend, RequestOptions } from '@angular/http';

import {
  NavBarComponent,
  AuthGuard,
  LoginService,
  CrediCardService,
  HttpService
} from './index';


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
      useFactory: (backend: XHRBackend, options: RequestOptions) => {
        return new HttpService(backend, options);
      },
      deps: [XHRBackend, RequestOptions]
    },


    LoginService,
    AuthGuard,
    CrediCardService,

    {
      provide:CrediCardService,
      useClass:CrediCardService
    }

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
