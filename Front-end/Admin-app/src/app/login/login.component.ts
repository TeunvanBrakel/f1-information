import { ValueConverter } from '@angular/compiler/src/render3/view/template';
import { Component, OnInit } from '@angular/core';
import { waitForAsync } from '@angular/core/testing';
import { repeat } from 'rxjs';
import { AuthService } from '../_services/auth.service';
import { TokenStorageService } from '../_services/token-storage.service';
import jwtDecode from 'jwt-decode';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: any = {
    username: null,
    password: null,
  };
  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = "";
  roles: string[] = [];
  failedLogin: number = 0;
  fails: string | null= "";

  constructor(private authService: AuthService, private tokenStorage: TokenStorageService) { }

  async ngOnInit(): Promise<void> {
    if(this.tokenStorage.getToken()){
      this.isLoggedIn = true;
      this.roles = this.tokenStorage.getUser();
    }
    if(localStorage.getItem("fails") != null){
      this.fails = window.localStorage.getItem("fails");
      if(this.fails == "1"){
        this.failedLogin = 1;
      }
      else if(this.fails == "2"){
        this.failedLogin = 2;
      }else if(this.fails == "3"){
        this.failedLogin = 3;
      }else if(this.fails == "4"){
        this.failedLogin = 4;
      }
    }
  }

  onSubmit(): void{
    const { username, password } = this.form;
    this.authService.login(username, password).subscribe(
      async data =>{
        this.tokenStorage.saveToken(data);
        this.tokenStorage.saveUser(data);
        if(this.tokenStorage.getRole(data) != "Admin"){
          this.tokenStorage.signOut();
          this.errorMessage = "You are not permitted to login to this site."
          this.failedLogin = this.failedLogin+1;
          localStorage.setItem("fails", this.failedLogin.toLocaleString());
          this.fails = window.localStorage.getItem("fails");
          this.isLoginFailed = true;
          if(this.fails == "5"){
            await new Promise(f => setTimeout(f, 60000));
            this.failedLogin = 0;
            localStorage.setItem("fails", this.failedLogin.toLocaleString());
            this.fails = window.localStorage.getItem("fails");
          }
        }else{
          this.isLoginFailed = false;
          this.isLoggedIn = true;
          this.tokenStorage.saveUser(username);
          this.roles = this.tokenStorage.getUser();
          this.reloadPage();
        }
      },
      async err => {
        this.errorMessage = err.title;
        this.failedLogin = this.failedLogin+1;
        localStorage.setItem("fails", this.failedLogin.toLocaleString());
        this.fails = window.localStorage.getItem("fails");
        this.isLoginFailed = true;
        if(this.fails == "5"){
          await new Promise(f => setTimeout(f, 60000));
          this.failedLogin = 0;
          localStorage.setItem("fails", this.failedLogin.toLocaleString());
          this.fails = window.localStorage.getItem("fails");
        }
      }
    );
  }

  reloadPage(): void{
    window.location.reload();
  }

}
