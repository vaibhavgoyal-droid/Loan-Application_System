import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http'
import { LoanRequest } from '../model/loan-request';
import { Observable } from 'rxjs';
import { throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

@Injectable()
export class LoanRequestService {
  private usersUrl! : string;
  
  constructor(private http: HttpClient) {
    this.usersUrl = 'https://localhost:7140';
   }

   headers={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }

   public findAllByUserId(userId: number): Observable<LoanRequest[]> {
    return this.http.get<LoanRequest[]>(this.usersUrl + `/LoanRequest/GetByUserId/${userId}`, this.headers).pipe(retry(1),catchError(this.handleError));
  }

  public save(user: LoanRequest) {
    return this.http.post<LoanRequest>(this.usersUrl + "/LoanRequest" ,JSON.stringify(user), this.headers).pipe(retry(1),catchError(this.handleError));
  }

  public reject(loanrequestId: any) {
    return this.http.put<LoanRequest>(this.usersUrl + `/LoanRequest/RejectRequest/${loanrequestId}` ,this.headers).pipe(retry(1),catchError(this.handleError));
  }

  public delete(loanrequestId:any){
    return this.http.delete<LoanRequest>(this.usersUrl + `/LoanRequest/${loanrequestId}` ,this.headers).pipe(retry(1),catchError(this.handleError));
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
