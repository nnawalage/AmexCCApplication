import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { appRoutes } from './routes';
import{NavBarComponent} from './index';
import {DashboardModule} from './dashboard/dashboard.module';
import {UserModule} from './user/user.module';
import {SharedModule} from './shared/shared.module';
@NgModule({
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    DashboardModule,
    UserModule,
    SharedModule
  ],
  declarations: [
    AppComponent, NavBarComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
