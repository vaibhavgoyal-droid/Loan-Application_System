import { Component,Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LoanRequest } from '../model/loan-request';
import { LoanRequestService } from '../service/loan-request.service';
import { CookieService } from 'ngx-cookie-service';
// import { Router } from '@angular/router';

@Component({
  selector: 'app-loan-request-form',
  templateUrl: './loan-request-form.component.html',
  styleUrls: ['./loan-request-form.component.css']
})
export class LoanRequestFormComponent {
  
  @Input() clientDetails = {  loanrequestId : 0,
                              userId : parseInt(this.getIdFromCookie()),
                              propertyAddress : '',
                              loanAmount : 0,
                              loanTenure : 0,
                              salary : 0,
                              status : ''};
  constructor(public loanRequestService: LoanRequestService,public router: Router,private cookieService: CookieService) {}
  ngOnInit() {}
  // loanAmount: number | null = null; showPlaceholder: boolean = true; 
  // onInput() { this.showPlaceholder = false; } 
  // onFocus() { this.showPlaceholder = false; } 
  // onBlur() { if (!this.loanAmount) { this.showPlaceholder = true; } }
  
  getIdFromCookie(): string {
    return this.cookieService.get('userId');
  }


  onSubmit(dataClient: any){
      console.log(this.clientDetails);
      this.loanRequestService.save(this.clientDetails).subscribe((data:{})=>{
        this.router.navigate(['/users']);
      });

  }

}
