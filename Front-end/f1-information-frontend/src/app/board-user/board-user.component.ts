import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { TokenStorageService } from '../_services/token-storage.service';
import { UserService } from '../_services/user.service';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json'}),
  responseType: 'text' as const
};

@Component({
  selector: 'app-board-user',
  templateUrl: './board-user.component.html',
  styleUrls: ['./board-user.component.css']
})
export class BoardUserComponent implements OnInit {
  form: any = {
    reporterUsername: null,
  };
  users: [] | any;
  errorMessage: string = "";
  content?: string;
  constructor(private userService : UserService, private tokenStorage :TokenStorageService,  private http: HttpClient, private authService: AuthService) { }

  ngOnInit(): void {
    if(this.tokenStorage.checkRole() == true)
    this.content = this.tokenStorage.getUser();
  }

  public async FindUser(name: string){
    await this.http.get<any>('https://localhost:44381/api/Name/UserNames').forEach(value => this.users = value.valueOf());
    console.log(this.users);
  }

  public async ReportUser(name: string){
    await this.FindUser(name);
    if(this.users.includes(name)){
      this.authService.report(name).subscribe(
        data => console.log(data));
    }else{
      this.errorMessage = "The name is not a valid username."
    }
  }
}
