import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TokenStorageService } from '../_services/token-storage.service';


@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  users: object | any;

  constructor(
    private http: HttpClient,
    private tokenStorage: TokenStorageService,
  ) { }

  ngOnInit(): void {
    this.GetAllUsers();
  }

  private GetAllUsers() {
    var token = this.tokenStorage.getToken()
    this.http.post('https://localhost:44381/api/Name/GetNames',{
      token,
    } ,this.httpOptions).subscribe(
      data =>{
        console.log(data);
        this.users=data;
      }
    );
  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'}),
    responseType: 'json' as const,
  };

}
