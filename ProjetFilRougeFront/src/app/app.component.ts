import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import pdfMake from 'pdfmake/build/pdfmake';
import pdfFonts from 'pdfmake/build/vfs_fonts';
pdfMake.vfs = pdfFonts.pdfMake.vfs;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent {

  isPassageQuiz = window.location.href == `${environment.siteUrl}/quiz`;
  title = 'ProjetFilRougeFront';
  user = sessionStorage['user'];
}
