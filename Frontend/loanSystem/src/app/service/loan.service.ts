import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http'
import { LoanData } from '../model/loan-data';
import { Observable } from 'rxjs';
import { throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class LoanService {
  private usersUrl! : string;
  
  constructor(private http: HttpClient) {
    this.usersUrl = 'https://localhost:7140';
   }

   headers={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }

   public findAllByUserId(userId: number): Observable<LoanData[]> {
    return this.http.get<LoanData[]>(this.usersUrl + `/Loan/GetByUserId/${userId}`).pipe(retry(1),catchError(this.handleError));
  }

  public save(user: LoanData) {
    return this.http.post<LoanData>(this.usersUrl + "/Loan", JSON.stringify(user),this.headers).pipe(retry(1),catchError(this.handleError));
  }

  public accept(loanrequestId:number){
    console.log(loanrequestId)
    return this.http.post<LoanData>(this.usersUrl+`/Loan/${loanrequestId}`, this.headers).pipe(retry(1),catchError(this.handleError));
  }

  // Error handling
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
