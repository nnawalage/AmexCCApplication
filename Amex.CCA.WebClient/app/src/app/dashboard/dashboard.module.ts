import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { dashBoardRoutes } from './dashboard.routes';
import { DashboardComponent } from './dashboard.component';


@NgModule({
    imports: [
        RouterModule.forChild(dashBoardRoutes)
    ],
    declarations: [
         DashboardComponent
    ],
    providers: [
        {provide:'Foo',useValue:Foo}
    ]
})


export class DashboardModule {

}
 function Foo(){
    return true;
}