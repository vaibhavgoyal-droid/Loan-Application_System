import { Component } from '@angular/core';
import { LoanRequest } from '../model/loan-request';
import { LoanRequestService } from '../service/loan-request.service';
import { CookieService } from 'ngx-cookie-service';
@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent {

  loanReq! : LoanRequest[]; 
  
  constructor(private userService: LoanRequestService,private cookieService: CookieService){

  }

  getIdFromCookie(): string {
    return this.cookieService.get('userId');
  }

  ngOnInit() {
    this.loadRequests()
    // throw new Error('Method not implemented.');
  }

  loadRequests(){
    this.userService.findAllByUserId(parseInt(this.getIdFromCookie())).subscribe(data=>{
      this.loanReq =data;
    });
  }

  onDeleting(loanrequestId:number){
    this.userService.delete(loanrequestId).subscribe((data:any)=>{
      this.loadRequests();
    })
  }

  onEditing(){
    
  }

}
