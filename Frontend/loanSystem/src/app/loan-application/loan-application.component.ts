import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-loan-application',
  templateUrl: './loan-application.component.html',
  styleUrls: ['./loan-application.component.css']
})
export class LoanApplicationComponent {
  title : string = "Loan Application"

  constructor(private cookieService: CookieService,private router: Router) {}


  // deleteCookie(name: string) {
  //   document.cookie = name + '=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;';
  // }

  onLogout(){
    // this.cookieService.deleteCookie('email');
    document.cookie = 'email' + '=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;';
    // this.cookieService.deleteCookie('password');
    document.cookie = 'password' + '=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;';
    this.router.navigate(['/login']);

  }
}
