import { Component } from "@angular/core";

@Component({
    selector: 'footer',
    templateUrl: './footer.template.html',
    styleUrls: ['./footer.styles.scss']
})
export class FooterComponent {
    private currentYear:number=new Date().getFullYear();
}
