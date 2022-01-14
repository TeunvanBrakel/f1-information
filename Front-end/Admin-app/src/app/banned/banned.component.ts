import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { TokenStorageService } from '../_services/token-storage.service';

@Component({
  selector: 'app-banned',
  templateUrl: './banned.component.html',
  styleUrls: ['./banned.component.css']
})
export class BannedComponent implements OnInit {

  users: object | any;
  constructor(
    private http: HttpClient,
    private tokenStorage: TokenStorageService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    if(this.tokenStorage.checkRole() == true)
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

  public async UnBanUser(username: string, email: string){
    
    await this.http.post('https://localhost:44381/api/Name/UnBanUser',{
      username,
      email,
    }, this.httpOptions).subscribe(
      data =>{
        console.log(data);
      }
    )
    await new Promise(f => setTimeout(f, 2000));
    this.router.navigateByUrl('users');
  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'}),
    responseType: 'json' as const,
  };


}
