import { Component, Input } from '@angular/core';
import { RegisterService } from '../service/register.service';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
// import { LoginService } from '../service/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  @Input() clientDetails = {  clientName : '',
                              password : '',
                              clientPhone: '',
                              clientEmail: ''};


autoClientDetails={
                  clientName : '',
                  password : this.getPasswordFromCookie(),
                  clientPhone: '',
                  clientEmail: this.getEmailFromCookie()
                  };
constructor(public registerService: RegisterService,public router: Router,private cookieService: CookieService) {}

setIdInCookie(userId: string): void {
  this.cookieService.set('userId', userId, 1); // 1 day expiration
}

setEmailInCookie(Email: string): void{
  this.cookieService.set('email',Email,1);
}

setPasswordInCookie(password: string): void{
  this.cookieService.set('password',password,1);
}

getIdFromCookie(): string {
  return this.cookieService.get('userId');
}

getEmailFromCookie(): string {
  return this.cookieService.get('email');
}

getPasswordFromCookie(): string {
  return this.cookieService.get('password');
}



ngOnInit() {
  console.log(this.autoClientDetails.clientEmail);
  console.log(this.autoClientDetails.password);
  this.registerService.check(this.autoClientDetails).subscribe((data:any)=>{
  if(data!=null){
    this.setIdInCookie(data.clientId);
    this.router.navigate(['/loanApplication']);
  }
  // else if(this.autoClientDetails.clientEmail!=null){
  //   window.alert("Couldn't save properly");
  // }
});
}


onSubmit(clientData:any){
console.log(this.clientDetails);
this.registerService.check(this.clientDetails).subscribe((data:any)=>{
  // console.log(data.clientId)
if(data!=null){
  console.log(data);
  console.log(data.password);
  this.setIdInCookie(data.clientId);
  this.setEmailInCookie(data.clientEmail);
  this.setPasswordInCookie(data.password);
  // console.log(this.getIdFromCookie());
  this.router.navigate(['/loanApplication']);
}
else{
  window.alert("Wrong Email or Password");
}
});

}

register(){
  this.router.navigate(['/register']);
}
}
