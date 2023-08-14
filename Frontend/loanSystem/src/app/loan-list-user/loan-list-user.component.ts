import { Component } from '@angular/core';
import { LoanData } from '../model/loan-data';
import { LoanService } from '../service/loan.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-loan-list-user',
  templateUrl: './loan-list-user.component.html',
  styleUrls: ['./loan-list-user.component.css']
})
export class LoanListUserComponent {

  loans! : LoanData[]; 
  
  constructor(private userService: LoanService,private cookieService: CookieService){

  }

  getIdFromCookie(): string {
    return this.cookieService.get('userId');
  }

  ngOnInit(): void {
    this.userService.findAllByUserId(parseInt(this.getIdFromCookie())).subscribe(data=>{
      this.loans =data;
    });
    // throw new Error('Method not implemented.');
  }
}
