import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, retry, throwError } from 'rxjs';
import { ClientRegister } from '../model/client-register';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  private usersUrl! : string;
  
  constructor(private http: HttpClient) {
    this.usersUrl = 'https://localhost:7140';
   }

   headers={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }

    public save(user: ClientRegister) {
      return this.http.post<ClientRegister>(this.usersUrl + "/Clients", JSON.stringify(user),this.headers).pipe(retry(1),catchError(this.handleError));
    }

    public check(user: ClientRegister) {
      return this.http.post<ClientRegister>(this.usersUrl + "/Clients/login", JSON.stringify(user),this.headers).pipe(retry(1),catchError(this.handleError));
    }

    public changePassword(user: ClientRegister){
      return this.http.put<ClientRegister>(this.usersUrl + "/Clients/forgotPassword", JSON.stringify(user),this.headers).pipe(retry(1),catchError(this.handleError));
    }

  handleError(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(() => {
      return errorMessage;
    });
  }
}
