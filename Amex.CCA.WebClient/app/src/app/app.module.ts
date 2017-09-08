import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { appRoutes } from './routes';
import { UserModule } from './user/user.module';
import { SharedModule } from './shared/shared.module';
import {
  NavBarComponent,
  AuthGuard,
  LoginService
} from './index';

// import { LoginService } from './services/login.service';
// import {AuthGuard} from './services/router-guard.service';
export function Foo() {
  return true;
}

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
  providers: [LoginService,AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
