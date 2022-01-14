import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import jwtDecode from 'jwt-decode';

const TOKEN_KEY = 'auth-token';
const USER_KEY = 'auth-user';

@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {

  constructor(private router: Router) { }

  signOut(): void {
    window.sessionStorage.clear();
  }

  public saveToken(token: string): void{
    window.sessionStorage.removeItem(TOKEN_KEY);
    window.sessionStorage.setItem(TOKEN_KEY, token);
  }

  public getToken(): string | null {
    if(window.sessionStorage.getItem(TOKEN_KEY) == undefined){
      return null;
    }
    return window.sessionStorage.getItem(TOKEN_KEY);
  } 

  public saveUser(user: any): void {
    window.sessionStorage.removeItem(USER_KEY);
    window.sessionStorage.setItem(USER_KEY, JSON.stringify(user));
  }

  public getUser(): any {
    const user = window.sessionStorage.getItem(USER_KEY);
    if (user) {
      return JSON.parse(user);
    }
    return {};
  }

  public getRole(token: string ): string | null {
    var user  : any  = jwtDecode(token);
    var result = user.role;
    return result;
  }

  public checkRole(): boolean {
    var token = this.getToken();
    if(token == undefined){
      this.router.navigateByUrl('login');
      return false;
    }else{
      if(this.getRole(token) != "Admin"){
        this.router.navigateByUrl('login');
        return false;
      }
      return true;
    }
  }
}
