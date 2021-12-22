import { Component } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  loginPage: boolean = true;

  constructor(
    private router: Router,
    ) {}
  
  ngOnInit(): void {
    this.IsCurrentPageLogin();
  }

  private IsCurrentPageLogin(){
    console.log(window.location.href)
    if(window.location.href == "http://localhost:4200/#"){
      this.loginPage = true;
    }
    else{
      this.loginPage = false;
    }
  }
  public RegisterNewUser(){
    console.log("test");
  }

  public LoginUser(){
    console.log("123");
  }
}
