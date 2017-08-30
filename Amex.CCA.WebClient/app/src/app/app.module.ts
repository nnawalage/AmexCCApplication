import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { appRoutes } from './routes';
import { NavBarComponent } from './index';
import { UserModule } from './user/user.module';
import { SharedModule } from './shared/shared.module';

@NgModule({
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    SharedModule
  ],
  declarations: [
    AppComponent, NavBarComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
