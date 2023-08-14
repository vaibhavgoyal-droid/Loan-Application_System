import { Component, Input } from '@angular/core';
import { RegisterService } from '../service/register.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  @Input() clientDetails = {  clientName : '',
                              password : '',
                              clientPhone : '',
                              clientEmail : '',};
constructor(public registerService: RegisterService,public router: Router) {}
ngOnInit() {}

onSubmit(dataClient: any){
console.log(this.clientDetails);
this.registerService.save(this.clientDetails).subscribe((data:{})=>{
this.router.navigate(['/login']);
});

}
}
