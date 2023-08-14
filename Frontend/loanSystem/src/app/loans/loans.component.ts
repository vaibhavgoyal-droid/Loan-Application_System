import { Component, Input } from '@angular/core';
import { LoanService } from '../service/loan.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-loans',
  templateUrl: './loans.component.html',
  styleUrls: ['./loans.component.css']
})
export class LoansComponent {
  @Input() loanDetails = {  loanId: 0,
                            totalPA: 0,
                            remainingPA: 0,
                            remainingTime: 0,
                            monthlyEMI: 0,
                            userId: 0};
constructor(public loanRequestService: LoanService,public router: Router) {}
ngOnInit() {}
// loanAmount: number | null = null; showPlaceholder: boolean = true; 
// onInput() { this.showPlaceholder = false; } 
// onFocus() { this.showPlaceholder = false; } 
// onBlur() { if (!this.loanAmount) { this.showPlaceholder = true; } }

onSubmit(dataClient: any){
console.log(this.loanDetails);
this.loanRequestService.save(this.loanDetails).subscribe((data:{})=>{
this.router.navigate(['/users']);
});

}
}
