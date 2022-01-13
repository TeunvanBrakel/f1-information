import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';

const AUTH_API = 'https://localhost:44381/api/Token/';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json'}),
  responseType: 'text' as const
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(username: string, password: string) : Observable<any>{
    return this.http.post(AUTH_API + 'Authenticate', {
      username,
      password,
    }, httpOptions);
  }

  register(username: string, email: string, password: string) : Observable<any> {
    return this.http.post(AUTH_API + 'Signup', {
      username,
      email,
      password,
      code: 12345678,
    }, httpOptions);
  }

  report(username: string) :Observable<any>{
    return this.http.post('https://localhost:44381/api/Name/ReportUser', {
      username,
    }, httpOptions);
  }
}
