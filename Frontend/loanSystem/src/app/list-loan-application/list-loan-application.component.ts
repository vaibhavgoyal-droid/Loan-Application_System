import { Component } from '@angular/core';
import { LoanRequest } from '../model/loan-request';
import { LoanRequestService } from '../service/loan-request.service';
import { CookieService } from 'ngx-cookie-service';
import { LoanService } from '../service/loan.service';

@Component({
  selector: 'app-list-loan-application',
  templateUrl: './list-loan-application.component.html',
  styleUrls: ['./list-loan-application.component.css']
})
export class ListLoanApplicationComponent {
  loanReq! : LoanRequest[]; 
  
  constructor(private userService: LoanRequestService,private loanService: LoanService,private cookieService: CookieService){

  }

  getIdFromCookie(): string {
    return this.cookieService.get('userId');
  }

  ngOnInit() {
    this.loadLoans();
  }

  loadLoans(){
    this.userService.findAllByUserId(parseInt(this.getIdFromCookie())).subscribe(data=>{
      this.loanReq =data;
    });
  }

  onAccepting(loanrequestId:number){
    console.log(loanrequestId);
    this.loanService.accept(loanrequestId).subscribe((data:any)=>{
      this.loadLoans();
    });
  }

  onRejecting(loanrequestId:number){
    this.userService.reject(loanrequestId).subscribe((data:any)=>{
      this.loadLoans();
    });
  }

}
