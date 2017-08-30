import {NgModule} from '@angular/core';
import {HeaderComponent} from './header.component';
import { FooterComponent } from "./footer.component";
@NgModule({
imports:[],
declarations:[HeaderComponent,FooterComponent],
providers:[],
exports:[HeaderComponent,FooterComponent]
})
export class SharedModule{

}