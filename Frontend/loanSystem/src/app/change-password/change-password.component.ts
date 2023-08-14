import { Component, Input } from '@angular/core';
import { RegisterService } from '../service/register.service';
import { Router } from '@angular/router';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent {
  @Input() clientDetails = {  clientName : '',
                              password : '',
                              clientPhone : '',
                              clientEmail : '',};
constructor(public registerService: RegisterService,public router: Router) {}
ngOnInit() {}

onSubmit(dataClient: any){
console.log(this.clientDetails);
this.registerService.changePassword(this.clientDetails).subscribe((data:any)=>{
  if(data==null)
  {
    window.alert("Your Previous Details Do Not Match")
  }
  else{
    this.router.navigate(['/login']);
  }
});

}
}
